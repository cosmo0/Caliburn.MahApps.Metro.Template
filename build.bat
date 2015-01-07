@echo off

powershell "Import-Module .\psake.psm1 ; Invoke-Psake .\build.ps1 ; exit $LASTEXITCODE"