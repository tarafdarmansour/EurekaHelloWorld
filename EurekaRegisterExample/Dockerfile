FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

ENV APP_HOME /opt/app
RUN mkdir $APP_HOME
WORKDIR $APP_HOME


COPY EurekaRegisterExample/EurekaRegisterExample.csproj $APP_HOME/EurekaRegisterExample/
RUN  cd $APP_HOME/EurekaRegisterExample && dotnet restore

COPY EurekaRegisterExample/. $APP_HOME/EurekaRegisterExample/
RUN cd $APP_HOME/EurekaRegisterExample && dotnet build


FROM build AS publish
WORKDIR $APP_HOME/EurekaRegisterExample
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS final
WORKDIR /app
COPY --from=publish /opt/app/EurekaRegisterExample/out ./
ENTRYPOINT ["dotnet", "EurekaRegisterExample.dll"]