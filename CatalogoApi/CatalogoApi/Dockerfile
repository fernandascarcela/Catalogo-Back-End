# Estágio 1: Build da Aplicação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia e restaura as dependências primeiro para aproveitar o cache
COPY *.csproj .
RUN dotnet restore

# Copia o resto do código fonte e publica a aplicação
COPY . .
RUN dotnet publish -c Release -o /app/publish --no-restore

# Estágio 2: Imagem Final de Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Copia a saída publicada do estágio de build
COPY --from=build /app/publish .

# Expõe a porta que a aplicação vai escutar dentro do container.
# Para .NET 8, o padrão é 8080.
EXPOSE 8080

# Define o ponto de entrada para rodar a aplicação
ENTRYPOINT ["dotnet", "CatalogoApi.dll"]