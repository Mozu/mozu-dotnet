nuget.exe install FAKE -ExcludeVersion -OutputDirectory packages
nuget.exe install SourceLink.Fake -ExcludeVersion -OutputDirectory packages -Pre
nuget.exe restore
packages\FAKE\tools\FAKE.exe build.fsx %*