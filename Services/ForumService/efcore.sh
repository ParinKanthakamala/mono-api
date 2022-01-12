echo "Quick Menu App"
PS3='Please enter action: '
options=("mysql create" "migrate" "install dotnet-ef" "update" "git quick push" "quit")

select opt in "${options[@]}"; do

  case $opt in
  "mysql create")
    echo "create new file(s) for mysql"
    dotnet ef dbcontext scaffold "Server=localhost;User=root;Password=password;Database=wordpress;Convert Zero Datetime=True;TreatTinyAsBoolean=True" pomelo.entityframeworkcore.mysql -c MyContext -o ./Entities -f
    break
    ;;
  "migrate")
    echo "start migrate"
    dotnet ef migrations add MyMigrations
    break
    ;;
  "install dotnet-ef")
    echo "install dotnet-ef"
    dotnet tool install --global dotnet-ef
    break
    ;;
  "update")
    echo "start migrate."
    dotnet ef database update
    break
    ;;
  "git quick push")
    git add .
    git commit -m "quick update"
    git push
    break
    ;;
  "quit")
    break
    ;;
  *)
    echo "invalid option $REPLY"
    break
    ;;
  esac
done
