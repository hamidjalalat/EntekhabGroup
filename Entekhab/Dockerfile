#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Entekhab/Entekhab.csproj", "Entekhab/"]
COPY ["Entekhab.Core/Entekhab.Core.csproj", "Entekhab.Core/"]
COPY ["Entekhab.Application/Entekhab.Application.csproj", "Entekhab.Application/"]
COPY ["Entekhab.Domain/Entekhab.Domain.csproj", "Entekhab.Domain/"]
COPY ["Entekhab.Persistence/Entekhab.Persistence.csproj", "Entekhab.Persistence/"]
COPY ["OvetimePolicies/OvetimePolicies.csproj", "OvetimePolicies/"]
RUN dotnet restore "Entekhab/Entekhab.csproj"
COPY . .
WORKDIR "/src/Entekhab"
RUN dotnet build "Entekhab.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Entekhab.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Entekhab.dll"]