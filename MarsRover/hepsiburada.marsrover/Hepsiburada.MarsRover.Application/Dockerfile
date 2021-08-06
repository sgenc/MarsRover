#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Hepsiburada.MarsRover.Application/Hepsiburada.MarsRover.Application.csproj", "Hepsiburada.MarsRover.Application/"]
COPY ["Hepsiburada.MarsRover.IOC/Hepsiburada.MarsRover.IOC.csproj", "Hepsiburada.MarsRover.IOC/"]
COPY ["Hepsiburada.MarsRover.Validator/Hepsiburada.MarsRover.Validator.csproj", "Hepsiburada.MarsRover.Validator/"]
COPY ["Hepsiburada.MarsRover.Core/Hepsiburada.MarsRover.Core.csproj", "Hepsiburada.MarsRover.Core/"]
COPY ["Hepsiburada.MarsRover.Service/Hepsiburada.MarsRover.Service.csproj", "Hepsiburada.MarsRover.Service/"]
RUN dotnet restore "Hepsiburada.MarsRover.Application/Hepsiburada.MarsRover.Application.csproj"
COPY . .
WORKDIR "/src/Hepsiburada.MarsRover.Application"
RUN dotnet build "Hepsiburada.MarsRover.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Hepsiburada.MarsRover.Application.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hepsiburada.MarsRover.Application.dll"]
