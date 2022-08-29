#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["LojaServicos.Api.Autor/LojaServicos.Api.Autor.csproj", "LojaServicos.Api.Autor/"]
RUN dotnet restore "LojaServicos.Api.Autor/LojaServicos.Api.Autor.csproj"
COPY . .
WORKDIR "/src/LojaServicos.Api.Autor"
RUN dotnet build "LojaServicos.Api.Autor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LojaServicos.Api.Autor.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LojaServicos.Api.Autor.dll"]