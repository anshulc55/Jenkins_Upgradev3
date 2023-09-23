FROM mcr.microsoft.com/dotnet/sdk:7.0 AS builder

WORKDIR /jenkins-plugin-model/src
COPY jenkins-plugin-model/src/Pi.Math/Pi.Math.csproj ./Pi.Math/
COPY jenkins-plugin-model/src/Pi.Runtime/Pi.Runtime.csproj ./Pi.Runtime/
COPY jenkins-plugin-model/src/Pi.Web/Pi.Web.csproj ./Pi.Web/

WORKDIR /jenkins-plugin-model//src/Pi.Web
RUN dotnet restore

# app image
FROM mcr.microsoft.com/dotnet/aspnet:7.0

EXPOSE 80
ENTRYPOINT ["dotnet", "Pi.Web.dll"]
CMD ["-m", "console", "-dp", "6"]
