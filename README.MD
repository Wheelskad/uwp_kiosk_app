# UWP Win10 Kiosk app
A test application whose purpose is to test the management of files with extension like .xls / .doc (office desktop app) in windows 10 (1803) kiosk mode

# AssignedAccessConfiguration file configuration to manage kiosk mode
Exemple of configuration which we use to allow excel to manage .xls file extension 
```
<AllAppsList>
	<AllowedApps>
		<App AppUserModelId="00d942cd-665a-4b7a-ba27-2f2b9c0d2792_kwmcxzszfer2y!App" />
		<App AppUserModelId="6c79869e-f250-405b-8134-f44c2fc1ef5d_kwmcxzszfer2y!App" />
		<App AppUserModelId="Microsoft.MicrosoftEdge_8wekyb3d8bbwe!MicrosoftEdge" />
		<App DesktopAppPath="%SystemDrive%\Program Files\Microsoft Office\root\Office16\EXCEL.EXE" />
	</AllowedApps>
</AllAppsList>
```
