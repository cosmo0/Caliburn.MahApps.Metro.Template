Properties {
	$LOCAL_PATH = Resolve-Path "."
	$NUGET_FOLDER = Join-Path $LOCAL_PATH "src\.nuget"
	$PACKAGES_PATH = Join-Path $LOCAL_PATH "src\packages"

	$NUGET = Join-Path $NUGET_FOLDER "nuget.exe"

	[xml]$PROJECTS = Get-Content (Join-Path $LOCAL_PATH "build.xml")
}

$ErrorActionPreference = "Stop"

Framework "4.0x86"
FormatTaskName "-------- {0} --------"

task default -depends Restore-Packages, Publish-Solution

# restores Nuget packages
task Restore-Packages {
	# restore tools
	& $NUGET install "$NUGET_FOLDER\packages.config" -OutputDirectory $PACKAGES_PATH

	# restore solution packages
	$PROJECTS.projects.solution | % {
		& $NUGET restore (Join-Path $LOCAL_PATH $_.path)
	}
}

# builds solution
task Publish-Solution -depends Restore-Packages {
	Exec {
		msbuild (Join-Path $LOCAL_PATH "src\CaliburnVisx.sln") /t:Build /p:Configuration=Release /p:Warnings=true /v:Normal /nologo /clp:WarningsOnly`;ErrorsOnly`;Summary`;PerformanceSummary
	}

	# TODO: dynamically change the contents of the template and export it
	# $PROJECTS.projects.solution | % {
	# 	Exec {
	# 		msbuild (Join-Path $LOCAL_PATH $_.path) /t:Build /p:Configuration=Release /p:Warnings=true /v:Normal /nologo /clp:WarningsOnly`;ErrorsOnly`;Summary`;PerformanceSummary
	# 	}
	# }
}
