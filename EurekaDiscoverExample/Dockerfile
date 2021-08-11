FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

ENV APP_HOME /opt/app
RUN mkdir $APP_HOME
WORKDIR $APP_HOME


COPY EurekaDiscoverExample/EurekaDiscoverExample.csproj $APP_HOME/EurekaDiscoverExample/
RUN  cd $APP_HOME/EurekaDiscoverExample && dotnet restore

COPY EurekaDiscoverExample/. $APP_HOME/EurekaDiscoverExample/
RUN cd $APP_HOME/EurekaDiscoverExample && dotnet build


FROM build AS publish
WORKDIR $APP_HOME/EurekaDiscoverExample
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS final
WORKDIR /app
COPY --from=publish /opt/app/EurekaDiscoverExample/out ./
ENTRYPOINT ["dotnet", "EurekaDiscoverExample.dll"]