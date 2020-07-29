FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build

RUN curl -sL https://deb.nodesource.com/setup_10.x | bash - && \
    apt-get install -y nodejs redis-server
	

WORKDIR /src
COPY ["./**/*.csproj", "./*.sln",   "./"]


RUN node -e "var fs=require('fs');fs.readdir(__dirname,function(err,files){files.filter((file)=>{return file.endsWith('.csproj')}).forEach((file)=>{var dir=file.substr(0,file.length-'.csproj'.length);var dest=dir+'/'+dir+'.csproj';if(!fs.existsSync(dir)){fs.mkdirSync(dir)}fs.rename(file,dest,console.log)})});"

RUN dotnet restore  --source https://api.nuget.org/v3/index.json --source http://ng-repo.dev.kibocommerce.com:8081/repository/nuget-localbuild/  Mozu.Api.sln
ENV mozu__appSettings__redis_host=localhost
COPY . .
ARG BUILD_VER=0.0.0-alphagit 
ENV BUILD_VER=$BUILD_VER
RUN dotnet build /p:Version=${BUILD_VER}  ./Mozu.Api.sln  -c Release --no-restore &&\
	dotnet pack -c Release --no-build --include-symbols /p:Version=${BUILD_VER} -o /buildoutput/nugs ./Mozu.Api.sln