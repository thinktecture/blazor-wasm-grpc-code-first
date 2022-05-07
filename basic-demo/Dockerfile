#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["GrpcCodeFirst.Api/GrpcCodeFirst.Api.csproj", "GrpcCodeFirst.Api/"]
COPY ["GrpcCodeFirst.Client/GrpcCodeFirst.Client.csproj", "GrpcCodeFirst.Client/"]
COPY ["GrpcCodeFirst.Shared/GrpcCodeFirst.Shared.csproj", "GrpcCodeFirst.Shared/"]
RUN dotnet restore "GrpcCodeFirst.Api/GrpcCodeFirst.Api.csproj"
COPY . .
WORKDIR "/src/GrpcCodeFirst.Api"
RUN dotnet build "GrpcCodeFirst.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GrpcCodeFirst.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GrpcCodeFirst.Api.dll"]