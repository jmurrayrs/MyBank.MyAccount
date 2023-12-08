# Passo 1: Usando a imagem do Debian slim
FROM debian:buster-slim

# Passo 2: Instale as dependências do Kafka
RUN apt-get update && \
    apt-get install -y default-jre wget

# Passo 3: Baixe e descompacte o Kafka
WORKDIR /opt
RUN wget https://downloads.apache.org/kafka/2.8.0/kafka_2.13-2.8.0.tgz && \
    tar -xzf kafka_2.13-2.8.0.tgz

# Passo 4: Instale as dependências do PostgreSQL e MongoDB
RUN apt-get install -y postgresql mongodb

# Passo 5: Exponha as portas do Kafka, PostgreSQL e MongoDB
EXPOSE 9092 5432 27017

# Passo 6: Copie a configuração do Kafka
COPY server.properties /opt/kafka_2.13-2.8.0/config/server.properties

# Passo 7: Inicie o Kafka, PostgreSQL e MongoDB (altere os comandos conforme necessário)
CMD ["/opt/kafka_2.13-2.8.0/bin/kafka-server-start.sh", "/opt/kafka_2.13-2.8.0/config/server.properties"] && \
    service postgresql start && \
    service mongodb start

# Use a imagem oficial do SDK do ASP.NET Core como base
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copie os arquivos do projeto e restaure as dependências
COPY *.csproj ./
RUN dotnet restore

# Copie todo o conteúdo do projeto e compile
COPY . .
RUN dotnet publish -c Release -o out

# Use a imagem oficial do ASP.NET Core Runtime como base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

# Comando padrão para iniciar a aplicação ao iniciar o contêiner
CMD ["dotnet", "MyBank.MyAccount.dll"]
