$scriptDir = Split-Path -Path $MyInvocation.MyCommand.Definition -Parent
Write-Output $scriptDir
$dirApi = Join-Path -Path $scriptDir -ChildPath "/FileHandler/Filehandler.Api"
Write-Output $dirApi
$dirService = Join-Path -Path $scriptDir -ChildPath "/FileHandler/Filehandler.Service"
Write-Output $dirService
Start-Process -FilePath 'docker-compose' -WorkingDirectory $scriptDir -ArgumentList 'up'
Start-Process -FilePath 'dotnet' -WorkingDirectory $dirApi -ArgumentList 'run'
Start-Process -FilePath 'dotnet' -WorkingDirectory $dirService -ArgumentList 'run'
Start-Process "https://localhost:5001/Swagger"
Start-Process "http://localhost:15672/"


