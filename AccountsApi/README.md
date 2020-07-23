# rg.diy.dot-net-core.accounting
Sample programs on Asp.net core web api


#To run the application withouth Mongo db
## do following changes in method ConfigureServices of Class Startup 
## Uncomment the below line 
## services.AddSingleton<IAccountRepository, MockAccountRepository>(); 
## comment the below line
## services.AddSingleton<IAccountRepository, AccountMongoDbRepository>();


# How to build docker image
docker build -t raj.diy.webapi.accountapi:0.0.1 .

# To verify the Image
docker images
 raj.diy.webapi.accountapi              0.0.1
 mcr.microsoft.com/dotnet/core/sdk      3.1-buster         
 mcr.microsoft.com/dotnet/core/aspnet   3.1-buster-slim

# To run the docker
docker run -it --rm -p 8080:80 raj.diy.webapi.accountapi:0.0.1

# To run or verify the app from docker container
## check the container
docker ps 
##open browser and type http://localhost:8080/bankaccounts