FROM mcr.microsoft.com/dotnet/aspnet:3.1
WORKDIR /app

# Copy output
COPY ./publish .

EXPOSE 80

EXPOSE 1433

ENTRYPOINT ["dotnet", "api.dll"]
# CMD dotnet api.dll:
