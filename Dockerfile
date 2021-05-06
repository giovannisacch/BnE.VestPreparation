#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
ARG debug='1'
ENV DEBUG ${debug}
WORKDIR /src
COPY . .

RUN dotnet restore --ignore-failed-sources || :
RUN (test $DEBUG -eq 1 && dotnet publish -c Debug -o /app) || (test $DEBUG -eq 0 && dotnet publish -c Release -o /app)

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
ARG deploy_env='Development'
ARG port='80'
ARG porthttps='443'
ARG debug='1'
ENV DEBUG ${debug}

ENV ASPNETCORE_ENVIRONMENT ${deploy_env}
ENV ASPNETCORE_URLS http://0.0.0.0:${port};https://0.0.0.0:${porthttps}
ENV TZ=America/Sao_Paulo
RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone
RUN DEBIAN_FRONTEND=noninteractive apt-get install -y --no-install-recommends tzdata
RUN dpkg-reconfigure --frontend noninteractive tzdata
RUN dotnet dev-certs https

WORKDIR /app
COPY --from=0 /app .
CMD ["/bin/bash", "-c", "dotnet BnE.EducationVest.API.dll"]
EXPOSE ${port}