# pm2 start dotnet -p Web.Client.csproj watch run

echo "Quick Menu App"
PS3='Please enter action: '
options=("dev" "build" "quit")
select opt in "${options[@]}"; do
    case $opt in
    "dev")
        dotnet watch -p Web.Client.csproj run
        break
        ;;
    "build")
        rm -r ./app/
        # dotnet build Web.Client.csproj -c Release -o ./app/
        # dotnet publish -r linux-x64 --self-contained false -o ./app/
        dotnet publish -r osx-x64 -o ./app/
        # cd app
        # dotnet ApiGateway.dll
        # cd ..
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
