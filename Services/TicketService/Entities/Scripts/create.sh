clear

cd ..
rm *.cs
cd Scripts
dotnet new webapi --name Website.Core.Entities --output ./
dotnet add package Microsoft.EntityFrameworkCore --version 3.1.6
dotnet add package Microsoft.EntityFrameworkCore.Design --version 3.1.6
dotnet add package Pomelo.Entityframeworkcore.MySql --version 3.1.2

dotnet ef dbcontext scaffold "Server=localhost;User=root;Password=password;Database=perfex;Convert Zero Datetime=True" pomelo.entityframeworkcore.mysql -c MyContext -o ./ -t customfields -t ticket_attachments -t ticket_replies -t tickets -t tickets_pipe_log -t tickets_predefined_replies -t tickets_priorities -t tickets_status -f

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
