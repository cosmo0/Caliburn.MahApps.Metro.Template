Clear-Host

$source = [System.IO.Path]::GetFullPath(".\CaliburnTemplate")
$dest = [System.IO.Path]::GetFullPath(".\_template")

# clear destination folder
if (Test-Path $dest) {
  Write-Host "Remove current temp folder..."
  Remove-Item $dest -Recurse -Force
}

# copy files to temp folder
Write-Host "Copying files to temp folder" -NoNewLine
Get-ChildItem $source -Recurse -Exclude @("bin", "obj") `
  | ? { $_.FullName -notmatch "\\bin\\" -and $_.FullName -notmatch "\\obj\\" } `
  | % {
      Write-Host "." -NoNewLine
      Copy-Item -Path $_ -Destination (Join-Path $dest $_.FullName.Substring($source.length))
    }
Write-Host ""

# replace namespace in cs and xaml files
Write-Host "Modifying files contents" -NoNewLine
Get-ChildItem $dest -Recurse `
  | ? { $_.FullName -match ".*\.cs$" -or $_.FullName -match ".*\.xaml$" -or $_.FullName -match ".*\.csproj$" } `
  | % {
      Write-Host "." -NoNewLine
      $csContent = (Get-Content $_.FullName).replace('CaliburnTemplate', '$safeprojectname$')
      Set-Content -Path $_.FullName -Value $csContent
    }
Write-Host ""

# copy icon file

# copy and configure VS template file

# remove unwanted files

# zip the package

# copy the template to the proper install folder
