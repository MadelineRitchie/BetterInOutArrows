$ErrorActionPreference = 'Stop'
$VerbosePreference = 'Continue'

$modName = 'BetterInOutArrows'

$targetDir = "$($env:USERPROFILE)\Documents\Klei\OxygenNotIncluded\mods\Dev\$modName"

cd $PSScriptRoot

cd .\bin\Release

$fileList = @("$modName.dll", 'mod.yaml', 'mod_info.yaml')

foreach ($file in $fileList) {
    cp $file $targetDir -Force
}

$pngs = (ls '*.png')
foreach ($file in $pngs) {
    cp $file $targetDir -Force
}
