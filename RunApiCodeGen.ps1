
param(
[int]$Major=$(throw "Major param is required"),
[int]$Minor=$(throw "Minor param is required"),
[ValidateSet("ci","si","qa")]
[string]$Env=$(throw "Env param is required"),
[string]$GenPath=$(throw "GenPath param is required"),
[string]$CodeGenBaseUrl=$(throw "CodeGenBaseUrl param is required"),
[string]$AppClaim=$(throw "CodeGenBaseUrl param is required"),
[boolean]$RunPublisher=$true
)


if ($RunPublisher)
{
    $server = "";
    switch($env) 
    {
        "ci"{$server="http://aus02ncserv001.dev.volusion.com"}
        "si"{$server="http://AUS02NISERV001.dev.volusion.com"}
        "qa"{$server="http://services-mozu-qa.dev.volusion.com"}
    }

    $uri = "$server/Mozu.ApiAdmin.WebApi/publish/build/apimajorminor";

    $headers = @{
        "x-vol-app-claims" = "$AppClaim"
    };
    
    

    $publisherRequestBody = New-Object psobject
    Add-Member -InputObject $publisherRequestBody -MemberType NoteProperty -Name Major -Value $major
    Add-Member -InputObject $publisherRequestBody -MemberType NoteProperty -Name Minor -Value $minor

    $publisherRequestBodyJson = $publisherRequestBody | ConvertTo-Json
    Write-Host $publisherRequestBodyJson
    
    try {
        $response = Invoke-WebRequest -Method Post -Uri $uri -Body $publisherRequestBodyJson -Headers $headers -ContentType "application/json; charset=utf-8" -UseBasicParsing
        Write-Host $response
        Write-Host $response.Headers
        Write-Host $response.StatusCode
    }
    catch [System.Net.WebException] {
         Write-Host $_.Exception.ToString()
         throw;
    }
}

$CodeGenServer = "$CodeGenBaseUrl/Mozu.ApiCodeGen.WebApi"


try {
    $response = Invoke-WebRequest -Method Get -Uri "$CodeGenServer/sdkcodegen/$env/versions"  -ContentType "application/json; charset=utf-8" -UseBasicParsing

    Write-Host $response
    Write-Host $response.Headers
    Write-Host $response.StatusCode
    $versions = ConvertFrom-Json $response

    $versionToUse = $versions[0]

} catch [System.Net.WebException]
{
     Write-Host $_.Exception.ToString()
     throw;
}

#$body = "{""environment"": ""$env"",""apiVersion"": ""$versionToUse"",""createChangeLog"": ""false"",""changeLogSourceApiVersion"": ""$versionToUse"",""languages"":  [""csharp""],""destinationDirectory"": ""$GenPath""}"

$body = New-Object psobject
$languages = @("csharp")
Add-Member -InputObject $body -MemberType NoteProperty -Name Environment -Value $env
Add-Member -InputObject $body -MemberType NoteProperty -Name ApiVersion -Value $versionToUse
Add-Member -InputObject $body -MemberType NoteProperty -Name CreateChangeLog -Value false
Add-Member -InputObject $body -MemberType NoteProperty -Name ChangeLogSourceApiVersion -Value $versionToUse
Add-Member -InputObject $body -MemberType NoteProperty -Name DestinationDirectory -Value $GenPath
Add-Member -InputObject $body -MemberType NoteProperty -Name Languages -Value $languages

$jsonBody = $body | ConvertTo-Json
Write-Host $jsonBody

try 
{
    $response = Invoke-WebRequest -Method Post -Uri "$CodeGenServer/sdkcodegen" -Body $jsonBody  -ContentType "application/json; charset=utf-8" -ErrorAction Stop -UseBasicParsing
    Write-Host $response.StatusCode
    Write-Host $response.Headers
}
catch [System.Net.WebException] 
{
    Write-Host $_.Exception.ToString()
    throw;
}
