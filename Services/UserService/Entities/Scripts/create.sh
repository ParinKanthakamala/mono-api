clear

cd ..
rm *.cs
cd Scripts
dotnet new webapi --name Website.Core.Entities --output ./
dotnet add package Microsoft.EntityFrameworkCore --version 3.1.6
dotnet add package Microsoft.EntityFrameworkCore.Design --version 3.1.6
dotnet add package Pomelo.Entityframeworkcore.MySql --version 3.1.2

dotnet ef dbcontext scaffold "Server=localhost;User=root;Password=password;Database=perfex;Convert Zero Datetime=True" pomelo.entityframeworkcore.mysql -c UserContext -o ./ -t activity_log -t clients -t consent_purposes -t consents -t contact_permissions -t contacts -t customer_admins -t customer_groups -t customers_groups -t departments -t gdpr_requests -t lead_activity_log -t notes -t roles -t sessions -t shared_customer_files -t staff -t staff_departments -t staff_permissions -t user_auto_login -t user_meta -f

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
