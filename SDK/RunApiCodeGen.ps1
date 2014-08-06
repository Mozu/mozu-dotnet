# Sample runline
# .\codegen -Major 1 -Minor 9 -Env "ci" -GenPath "\\\\dev.volusion.com\\data\\QA\\integrations\\ImportExport" -CodeGenBaseUrl "https://6c42d67b88eb2b6.a.passageway.io" -AppClaim "vbOcoAEuoHXZJPQUrbZA/kh/d95wt8YNIfdAGlmvRrSMpWX6AK3UyBhrrbEj6+TCjgerVxSGfC7x/FzVLDRXrel/sSQdalb7Y+Y+tcIuKnAy96MwSRELA217QrK1DK435I5pEaVJCtSfKqcNanK8R2p5ab2RuvYAfeHwxGvBVHnTempQruRoAjNKsKlKnlG+Ag7sCPKz7lWQhvMjQ09rIpBEqYfZSQ04WV+HYV3OkPEWLswDvcOhwvBsHHW/Qu1RooM10qbPVU4wm+0xmQrrk4pLbhrKepu7VRhlgHdSGnS9hrxnsp84C+VqaXoyREj+XccsF2Z2zcqYxkai+jNaM4i+gecOwhTHmoZVU/ac3tOEE+gHTz3ze5ikPdpIghAX4FkgIqV7gb4iLFGp4Cx8rrD3qu1Y0aVRobLQD2M8lA0sQNqwHjMB0Zq088V8moSSDUaJ95TO/CXh0UUW8EPRSDFK3rhIxsjgmaiZnM5QZR5XtSh8xpxMlA0QOlfQIGqQwO3ng85Y+zEo5l6ljvzEY8hrKT1j5Ro+PSMFRv6rqRnL3CswCs9FCc1+3ANUtxo3" -RunPublisher:$false 
 
 
 param(
[int]$Major=$(throw"Major param is required"),
[int]$Minor=$(throw"Minor param is required"),
[ValidateSet("ci","si","qa")]
[string]$Env=$(throw"Env param is required"),
[string]$GenPath=$(throw"GenPath param is required"),
[string]$CodeGenBaseUrl=$(throw"CodeGenBaseUrl param is required"),
[string]$AppClaim=$(throw"CodeGenBaseUrl param is required"),
[boolean]$RunPublisher
)
 
 
if ($RunPublisher)
{
    $server="";
    switch($env) 
    {
        "ci"{$server="http://aus02ncserv001.dev.volusion.com"}
        "si"{$server="http://AUS02NISERV001.dev.volusion.com"}
        "qa"{$server="http://services-mozu-qa.dev.volusion.com"}
    }
 
    $uri="$server/Mozu.ApiAdmin.WebApi/publish/build/apimajorminor";
 
    $headers= @{
        "x-vol-app-claims"="$AppClaim"
        "accept"="application/json"
    };
 
    $body="{
        ""major"" : ""$major"",
        ""minor"" : ""$minor""
    }";
 
    try {
        Invoke-RestMethod-MethodPost-Uri$uri-Body$body-Headers$headers  -ContentType"application/json"
    }
    catch[System.Net.WebException] {
         Write-Host$_.Exception.ToString()
         throw;
    }
}
 
$CodeGenServer="$CodeGenBaseUrl/Mozu.ApiCodeGen.WebApi"
 
 
try {
    $response=Invoke-WebRequest-MethodGet-Uri"$CodeGenServer/sdkcodegen/$env/versions"  -ContentType"application/json"-Proxy"http://localhost:8888"
 
    Write-Host$response
    Write-Host$response.Headers
    Write-Host$response.StatusCode
    $versions=ConvertFrom-Json$response
 
    $versionToUse=$versions[0]
 
} catch[System.Net.WebException]
{
     Write-Host$_.Exception.ToString()
     throw;
}
 
$body="{
    ""environment"": ""$env"",
    ""apiVersion"": ""$versionToUse"",
    ""createChangeLog"": ""false"",
    ""changeLogSourceApiVersion"": ""$versionToUse"",
    ""languages"":  [""csharp"",""java"", ""php"",""ios""],
    ""destinationDirectory"": ""$GenPath""
}"
 
Write-Host$body
 
try 
{
    $response=Invoke-WebRequest-MethodPost-Uri"$CodeGenServer/sdkcodegen"-Body$body-Headers$headers-ContentType"application/json"-ErrorActionStop
    Write-Host$response.StatusCode
    Write-Host$response.Headers
}
catch[System.Net.WebException] 
{
    Write-Host$_.Exception.ToString()
    throw;
}
