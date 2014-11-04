
var viewModel = function () {
    var self = this;
    self.appVersion = ko.observable();
    self.apiVersion = ko.observable();

    self.loadVersion = function () {
        $.ajax({
            url:  "api/version",
            type: "GET",
            dataType: "json",
            success: function (data) {
                self.appVersion(data.appVersion);
                self.apiVersion(data.sdkVersion);

                ko.applyBindings(window.viewModel);
            }
        });
    };

    self.loadVersion();
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
   


    window.viewModel = new viewModel();
});