
var pathName = window.location.pathname;

var applicationInfo = {
    'nameSpace': ko.observable(),
    'version': ko.observable(),
    'package': ko.observable()
}


var viewModel = function () {
    var self = this;
    self.appVersion = ko.observable();
    self.apiVersion = ko.observable();
    self.appInfo = ko.mapping.fromJS(applicationInfo);

    self.loadVersion = function () {
        $.ajax({
            url: pathName+ "api/version",
            type: "GET",
            dataType: "json",
            success: function (data) {
                self.appVersion(data.appVersion);
                self.apiVersion(data.sdkVersion);

            }
        });
    };


    self.getAppInfo = function() {
        $.ajax({
            url: pathName + "api/application/info",
            type: "GET",
            dataType: "json",
            success: function (data) {
                ko.mapping.fromJS(data, self.appInfo);
                console.log(self.appInfo);
            }
        });
    }

    //self.getAppInfo();

    self.init = function() {
        self.loadVersion();
        self.getAppInfo();
    }
};



function enableTabs() {
    $(".tabs a").click(function (e) {
        var tabElement = e.target.parentElement;
        var newTab = e.target;
        var parent = tabElement.parentElement;
        var activeTab = $(parent).find('.active');
        var activeTabId = activeTab.data('tab-id');
        var newTabId = $(newTab).data('tab-id');

        if (activeTabId == newTabId) return;

        activeTab.removeClass('active');
        $(newTab).addClass('active');


        $('#' + activeTabId).fadeOut('fast', function () {
            $('#' + newTabId).fadeIn('fast');
            var loadScript = $(newTab).data('loadscript');
            if (loadScript != "" && loadScript != null) {
                var fn = new Function("viewModel." + loadScript);
                fn();
            }
        });

    });

}

function closeError() {
    $("#serverError").hide();
}

$(document).ajaxError(function (event, jqxhr, settings, exception) {
    console.log(jqxhr);
    //if (jqxhr.status >= 200 && jqxhr.status <= 300) return;
    if (jqxhr.responseJSON != null)
        $("#serverErrorMessage").html(jqxhr.responseJSON.message);
    else if (jqxhr.responseText != null)
        $("#serverErrorMessage").html(jqxhr.responseText);
    else {
        $("#serverErrorMessage").html(jqxhr.statusText);
    }

    $("#serverError").show();
});

$(function () {

    $.ajaxPrefilter(function (options, _, jqXHR) {
        jqXHR.setRequestHeader('cookieToken', $("#cookieToken").val());
        jqXHR.setRequestHeader('formToken', $("#formToken").val());
        $("#serverError").hide();
        $("#progressIndicator").show();
        $("#companyCodesTbl").find("img").each(function () {
            $(this).hide();
        });
        $("#companyCodesTbl").find("#error").each(function () {
            $(this).hide();
        });
        jqXHR.complete(function () {
            $("#progressIndicator").hide();
        });

    });


    enableTabs();

    if (pathName == "/")
        pathName = "";

    if (pathName.indexOf("/", pathName.length - 1) == -1) pathName = pathName + "/";
    

    viewModel = new viewModel();
    ko.applyBindings(viewModel);
    viewModel.init();
});