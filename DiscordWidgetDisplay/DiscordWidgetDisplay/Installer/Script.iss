; This script is perhaps one of the simplest Inno Setup installer you can make. 
; All of the optional settings are left to their default settings. 

; See the Inno Setup documentation at http://www.jrsoftware.org/ for details on creating script files!    

;--------------------------------

#define AppName "Discord Widget Display"
#define AppPath "..\bin\Release\net6.0-windows\publish\\"
#define OutputPath "..\bin\Installers\\"
#define AppExecutableName "DiscordWidgetDisplay.exe"
#define AppVersion GetFileVersion(AppPath + AppExecutableName)
#define AppPublisher "PinguApps"
#define AppURL "http://www.pinguapps.com"

[Setup]
; NOTE: The value of AppId uniquely identifies this application. Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{4441D15A-7354-4E47-8234-5C9B87BC6C4E}
AppName={#AppName}
AppVersion={#AppVersion}
AppPublisher={#AppPublisher}
AppPublisherURL={#AppURL}
AppSupportURL={#AppURL}
AppUpdatesURL={#AppURL}
DefaultDirName={autopf}\{#AppPublisher}\{#AppName}
DefaultGroupName={#AppPublisher}
DisableProgramGroupPage=yes
LicenseFile=EULA.rtf
PrivilegesRequiredOverridesAllowed=dialog
OutputDir={#OutputPath}
OutputBaseFilename="{#AppName} {#AppVersion}"
Compression=lzma2
SolidCompression=yes
WizardSmallImageFile=Logos\PinguApps100.bmp,Logos\PinguApps125.bmp,Logos\PinguApps150.bmp,Logos\PinguApps175.bmp,Logos\PinguApps200.bmp,Logos\PinguApps225.bmp,Logos\PinguApps250.bmp
WizardStyle=modern

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}";

[Files]
Source: {#AppPath}{#AppExecutableName}; DestDir: "{app}"; Flags: ignoreversion
Source: "{#AppPath}*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{autoprograms}\{#AppName}"; Filename: "{app}\{#AppExecutableName}"
Name: "{autodesktop}\{#AppName}"; Filename: "{app}\{#AppExecutableName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#AppExecutableName}"; Description: "{cm:LaunchProgram,{#StringChange(AppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

[Code]