#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["LojaServicos.Api.CarrinhoCompra/LojaServicos.Api.CarrinhoCompra.csproj", "LojaServicos.Api.CarrinhoCompra/"]
RUN dotnet restore "LojaServicos.Api.CarrinhoCompra/LojaServicos.Api.CarrinhoCompra.csproj"
COPY . .
WORKDIR "/src/LojaServicos.Api.CarrinhoCompra"
RUN dotnet build "LojaServicos.Api.CarrinhoCompra.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LojaServicos.Api.CarrinhoCompra.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LojaServicos.Api.CarrinhoCompra.dll"]