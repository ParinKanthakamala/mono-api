clear



cd ..
rm *.cs
cd scripts
dotnet new webapi --name Docygen.Shared.Entities --output ./
dotnet add package Microsoft.EntityFrameworkCore --version 3.1.6
dotnet add package Microsoft.EntityFrameworkCore.Design --version 3.1.6
dotnet add package Pomelo.Entityframeworkcore.MySql --version 3.1.2
#dotnet add package Pomelo.Entityframeworkcore.MySql

dotnet ef dbcontext scaffold "Server=localhost;User=root;Password=password;Database=wordpress;Convert Zero Datetime=True;TreatTinyAsBoolean=True" pomelo.entityframeworkcore.mysql -c MyContext -o ./ -f 

#dotnet ef migrations add MyMigration
#dotnet ef database update


rm -rf bin
rm -rf obj 
rm -rf Properties
rm -rf Controllers
rm Program.cs
rm Startup.cs
rm *.json
rm *.csproj
rm WeatherForecast.cs
mv *.cs ../
 