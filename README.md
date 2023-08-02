"# CLothes-Shops-Backend" 
"# tienda-online-backend"

dotnet ef migrations add PrimeraMigracion --startup-project ../TiendaOnline/TiendaOnline.csproj

dotnet ef database update --startup-project ../TiendaOnline/TiendaOnline.csproj

DESPLEGAR EN HEROKU
https://dev.to/adevintaspain/desplegando-tu-api-de-net-core-gratis-en-heroku-5552