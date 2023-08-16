"# CLothes-Shops-Backend" 
"# tienda-online-backend"

dotnet ef migrations add PrimeraMigracion --startup-project ../ClotheShops/ClotheShops.csproj

dotnet ef database update --startup-project ../ClotheShops/ClotheShops.csproj

DESPLEGAR EN HEROKU
https://dev.to/adevintaspain/desplegando-tu-api-de-net-core-gratis-en-heroku-5552