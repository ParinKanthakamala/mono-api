clear

cd ..
rm *.cs
cd Scripts
dotnet new webapi --name Website.Core.Entities --output ./
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Pomelo.EntityFrameworkCore.MySql

#dotnet ef dbcontext scaffold "Server=localhost;User=root;Password=password;Database=mono-dev;Convert Zero Datetime=True" pomelo.entityframeworkcore.mysql -c UserContext -o ./ -f
#dotnet ef dbcontext scaffold "Server=localhost;User=root;Password=password;Database=mono-dev;Convert Zero Datetime=True;Trusted_Connection=True;" "Pomelo.EntityFrameworkCore.MySql" -c MyContext -o ./ -f
dotnet ef dbcontext -v scaffold "Server=localhost;User=root;Password=password;Database=mono-dev;Convert Zero Datetime=True;Trusted_Connection=True;" pomelo.entityframeworkcore.mysql -c MyContext -o ./ -f
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
