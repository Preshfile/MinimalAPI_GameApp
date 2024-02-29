# Game Store API

## Starting SQL Server

``` Powershell
$sa_password = "[PASSWORD GOES HERE]"
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=$sa_password" -e "MSSQL_PID=Evaluation" -p 1433:1433 -v sqlVolume:/var/opt/mssql --name mssql --hostname mssql -d --rm mcr.microsoft.com/mssql/server:2022-preview-ubuntu-22.04
```
