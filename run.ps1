$scriptDir = Split-Path -Path $MyInvocation.MyCommand.Definition -Parent
$dirApi = Join-Path -Path $scriptDir -ChildPath "/Filehandler.Api"
$dirService = Join-Path -Path $scriptDir -ChildPath "/Filehandler.Service"
Start-Process -FilePath 'docker-compose' -WorkingDirectory $scriptDir -ArgumentList 'up'
Start-Process -FilePath 'dotnet' -WorkingDirectory $dirApi -ArgumentList 'run'
Start-Process -FilePath 'dotnet' -WorkingDirectory $dirService -ArgumentList 'run'
Start-Process "https://localhost:5001/Swagger"
Start-Process "http://localhost:15672/"


