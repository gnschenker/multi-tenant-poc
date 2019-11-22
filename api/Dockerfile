FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /app
COPY api.csproj ./
RUN dotnet restore 
COPY . .
EXPOSE 5000
CMD dotnet run