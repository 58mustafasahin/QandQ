#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Presentation/QandQ.WebAPI/QandQ.WebAPI.csproj", "Presentation/QandQ.WebAPI/"]
COPY ["Core/QandQ.Application/QandQ.Application.csproj", "Core/QandQ.Application/"]
COPY ["Infrastructure/QandQ.Infrastructure/QandQ.Infrastructure.csproj", "Infrastructure/QandQ.Infrastructure/"]
COPY ["Core/QandQ.Domain/QandQ.Domain.csproj", "Core/QandQ.Domain/"]
COPY ["Infrastructure/QandQ.Persistence/QandQ.Persistence.csproj", "Infrastructure/QandQ.Persistence/"]
RUN dotnet restore "Presentation/QandQ.WebAPI/QandQ.WebAPI.csproj"
COPY . .
WORKDIR "/src/Presentation/QandQ.WebAPI"
RUN dotnet build "QandQ.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "QandQ.WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "QandQ.WebAPI.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet QandQ.WebAPI.dll