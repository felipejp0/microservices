# Use uma imagem base do OpenJDK
FROM openjdk:17-jdk-alpine

# Define o diretório de trabalho no contêiner
WORKDIR /app

# Copia o arquivo JAR gerado para dentro do contêiner
COPY target/demo-0.0.1-SNAPSHOT.jar /app/demo.jar

# Expõe a porta 8761 para o Eureka Server
EXPOSE 8761

# Comando para executar o Eureka Server
ENTRYPOINT ["java", "-jar", "/app/demo.jar"]
