Clear-Host

# Huge props to @Lycidas0815 to help me understand how the Visual Studio Template files work !

# Locations
$here = split-path -parent $MyInvocation.MyCommand.Definition
$source = [System.IO.Path]::GetFullPath(".\CaliburnTemplate")
$dest = [System.IO.Path]::GetFullPath(".\_template")
$zipFile = "$here\CaliburnTemplate.zip"

# clear destination folder
Write-Host "Removing existing artifacts..." -NoNewLine
if (Test-Path $dest) {
  Remove-Item $dest -Recurse -Force
}
if (Test-Path $zipFile) {
  Remove-Item $zipFile -Force
}
Write-Host " done"

# copy files to temp folder
Write-Host "Copying files to temp folder" -NoNewLine
Get-ChildItem $source -Recurse -Exclude @("bin", "obj") `
  | ? { $_.FullName -notmatch "\\bin\\" -and $_.FullName -notmatch "\\obj\\" } `
  | % {
      Write-Host "." -NoNewLine
      Copy-Item -Path $_ -Destination (Join-Path $dest $_.FullName.Substring($source.length))
    }
Write-Host " done"

# replace namespace in cs and xaml files
Write-Host "Modifying files contents" -NoNewLine
Get-ChildItem $dest -Recurse `
  | ? { $_.FullName -match ".*\.cs$" -or $_.FullName -match ".*\.xaml$" -or $_.FullName -match ".*\.csproj$" } `
  | % {
      Write-Host "." -NoNewLine
      $csContent = (Get-Content $_.FullName).replace('CaliburnTemplate', '$safeprojectname$')
      Set-Content -Path $_.FullName -Value $csContent
    }
Write-Host " done"

# copy icon and VS template files
# we could generate the template file automatically but I'm not sure it's worth it...
Write-Host "Copying resources files..." -NoNewLine
Copy-Item (Join-Path $here "resources\*") $dest
Write-Host " done"

# remove unwanted files
Write-Host "Clearing unwanted files..." -NoNewLine
Remove-Item "$dest\*.StyleCop"
Write-Host " done"

# zip the package
Write-Host "Zipping the file..."
$zip = "$here\7za.exe"
& $zip "a", "-tzip", $zipFile, "$dest\*", "-r"
Write-Host " done"

# copy the template to the proper install folder
Write-Host "Copying the template to my documents" -NoNewLine
$mydocs = [Environment]::GetFolderPath("MyDocuments")
Get-ChildItem "$myDocs" `
  | ? { $_.FullName -match "\\Visual Studio [\d]+" } `
  | % {
      Write-Host "." -NoNewLine
      Copy-Item $zipFile (Join-Path $_.FullName "Templates\ProjectTemplates\Visual C#")
  }
Write-Host " done"

Write-Host ""
Write-Host "The template has been generated and copied." -BackgroundColor Green -ForegroundColor Black
Write-Host "Please restart Visual Studio for it to appear in the new project list." -BackgroundColor Green -ForegroundColor Black
