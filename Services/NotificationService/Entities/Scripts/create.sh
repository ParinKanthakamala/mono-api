clear

cd ..
rm *.cs
cd Scripts
dotnet new webapi --name Website.Core.Entities --output ./
dotnet add package Microsoft.EntityFrameworkCore --version 3.1.6
dotnet add package Microsoft.EntityFrameworkCore.Design --version 3.1.6
dotnet add package Pomelo.Entityframeworkcore.MySql --version 3.1.2

dotnet ef dbcontext scaffold "Server=localhost;User=root;Password=password;Database=perfex;Convert Zero Datetime=True" pomelo.entityframeworkcore.mysql -c MyContext -o ./ -t announcements -t dismissed_announcements -t events -t mail_queue -t notifications -t reminders -t tracked_mails -f

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
