; -------------------------------
; Start

  !define MUI_FILE "PDFEncrypter"
  !define MUI_VERSION ""
  !define MUI_PRODUCT "4dots Software PDF Encrypter"
  !define PRODUCT_SHORTCUT "PDF Encrypter"
  !define MUI_ICON "pdf_encrypter_32.ico"
 ; !define LIBRARY_SHELL_EXTENSION

;  !define MUI_FINISHPAGE_SHOWREADME "$INSTDIR\readme.txt"

  !define MUI_CUSTOMFUNCTION_GUIINIT myGuiInit

  BrandingText "www.4dots-software.com"

  !include "MUI2.nsh"
  !include Library.nsh
  !include "x64.nsh"
  !include InstallOptions.nsh

  RequestExecutionLevel admin
  Name "4dots Software PDF Encrypter"
  OutFile "PDFEncrypterSetup.exe"

  InstallDir "$PROGRAMFILES\4dots Software\${PRODUCT_SHORTCUT}"

  InstallDirRegKey HKLM "Software\4dots Software\PDFEncrypter" ""

 !define DOT_MAJOR "2"
 !define DOT_MINOR "0"
 !define DOT_MINOR_MINOR "50727"

  var ALREADY_INSTALLED
 
;--------------------------------
;Interface Settings

  !define MUI_ABORTWARNING 
;--------------------------------
;General
 
  !insertmacro MUI_PAGE_WELCOME
  !insertmacro MUI_PAGE_LICENSE "license_agreement.rtf" 
 ; !insertmacro MUI_PAGE_COMPONENTS
  !insertmacro MUI_PAGE_DIRECTORY 
  !insertmacro MUI_PAGE_INSTFILES
  
  Page custom OptionsPage
  !insertmacro MUI_UNPAGE_CONFIRM
  !insertmacro MUI_UNPAGE_INSTFILES 

  !define MUI_FINISHPAGE_RUN 
  !define MUI_FINISHPAGE_RUN_FUNCTION "OpenWebpageFunction"
  !define MUI_FINISHPAGE_RUN_TEXT "Open Application Webpage for Information"
  !insertmacro MUI_PAGE_FINISH
  
;--------------------------------
;Languages
 
  !insertmacro MUI_LANGUAGE "English" 

Function AddStartMenu
;create start-menu items
  CreateDirectory "$SMPROGRAMS\${PRODUCT_SHORTCUT}"
  CreateShortCut "$SMPROGRAMS\${PRODUCT_SHORTCUT}\${PRODUCT_SHORTCUT}.lnk" "$INSTDIR\${MUI_FILE}.exe" "" "$INSTDIR\${MUI_FILE}.exe" 0
  CreateShortCut "$SMPROGRAMS\${PRODUCT_SHORTCUT}\PDF Encrypter Users Manual.chm.lnk" "$INSTDIR\PDF Encrypter Users Manual.chm" "" "$INSTDIR\PDF Encrypter Users Manual.chm" 0
  CreateShortCut "$SMPROGRAMS\${PRODUCT_SHORTCUT}\Uninstall.lnk" "$INSTDIR\Uninstall.exe" "" "$INSTDIR\Uninstall.exe" 0

Functionend

Function AddDesktopShortcut
;create desktop shortcut
  CreateShortCut "$DESKTOP\${PRODUCT_SHORTCUT}.lnk" "$INSTDIR\${MUI_FILE}.exe" ""

FunctionEnd

Function IntegrateWindowsExplorer

 ${If} ${RunningX64}

!ifndef LIBRARY_X64
 !define LIBRARY_X64
!endif

   ExecWait '"$INSTDIR\vcredist_x64.exe" /q'

  !insertmacro InstallLib REGDLL $ALREADY_INSTALLED NOREBOOT_NOTPROTECTED .\PDFEncrypterShellExtx64.dll $SYSDIR\PDFEncrypterShellExt.dll $SYSDIR
  SetRegView 64
  SetShellVarContext all

${Else}

   ExecWait '"$INSTDIR\vcredist_x86.exe" /q'
  !insertmacro InstallLib REGDLL $ALREADY_INSTALLED NOREBOOT_NOTPROTECTED .\PDFEncrypterShellExt_vs2008_w7_x86.dll $SYSDIR\PDFEncrypterShellExt.dll $SYSDIR

${EndIf}  



FunctionEnd

Function AddQuickLaunch
  CreateShortCut "$QUICKLAUNCH\${PRODUCT_SHORTCUT}.lnk" "$INSTDIR\${MUI_FILE}.exe" ""
FunctionEnd
 
;-------------------------------- 
;Installer Sections     

Section "install" installinfo
  SetShellVarContext all

 ${If} ${RunningX64}
  SetRegView 64
; 64bit things here

${Else}

; 32bit things here

${EndIf}  



;Add files
  SetOutPath "$INSTDIR"
;  inetc::get /SILENT "http://www.4dots-software.com/installmonetizer/PDFEncrypter.php" "$PLUGINSDIR\Installmanager.exe" /end
;  ExecWait "$PLUGINSDIR\Installmanager.exe 015" 

 Call IsDotNetInstalledAdv

  Delete $SYSDIR\PDFEncrypterShellExt.dll 
  File "..\..\..\Dotfuscated\${MUI_FILE}.exe"
;  File "readme.txt"
  File "..\..\..\helpfile\PDF Encrypter Users Manual.chm";
  File "license_agreement.rtf"
  File "vcredist_x64.exe"
  File "vcredist_x86.exe"
  File "itextsharp.dll"
  File "Initial Files\drm.dat"

CreateDirectory "$INSTDIR\ar-SA"
SetOutPath "$INSTDIR\ar-SA"
File "..\..\..\Dotfuscated\ar-SA\PDFEncrypter.resources.dll"
File "..\..\..\helpfile\ar-SA\PDF Encrypter Users Manual.chm"
CreateDirectory "$INSTDIR\be-BY"
SetOutPath "$INSTDIR\be-BY"
File "..\..\..\Dotfuscated\be-BY\PDFEncrypter.resources.dll"
File "..\..\..\helpfile\be-BY\PDF Encrypter Users Manual.chm"
CreateDirectory "$INSTDIR\cs-CZ"
SetOutPath "$INSTDIR\cs-CZ"
File "..\..\..\Dotfuscated\cs-CZ\PDFEncrypter.resources.dll"
File "..\..\..\helpfile\cs-CZ\PDF Encrypter Users Manual.chm"
CreateDirectory "$INSTDIR\da-DK"
SetOutPath "$INSTDIR\da-DK"
File "..\..\..\Dotfuscated\da-DK\PDFEncrypter.resources.dll"
File "..\..\..\helpfile\da-DK\PDF Encrypter Users Manual.chm"
CreateDirectory "$INSTDIR\de-DE"
SetOutPath "$INSTDIR\de-DE"
File "..\..\..\Dotfuscated\de-DE\PDFEncrypter.resources.dll"
File "..\..\..\helpfile\de-DE\PDF Encrypter Users Manual.chm"
CreateDirectory "$INSTDIR\el-GR"
SetOutPath "$INSTDIR\el-GR"
File "..\..\..\Dotfuscated\el-GR\PDFEncrypter.resources.dll"
File "..\..\..\helpfile\el-GR\PDF Encrypter Users Manual.chm"
CreateDirectory "$INSTDIR\es-ES"
SetOutPath "$INSTDIR\es-ES"
File "..\..\..\Dotfuscated\es-ES\PDFEncrypter.resources.dll"
File "..\..\..\helpfile\es-ES\PDF Encrypter Users Manual.chm"
CreateDirectory "$INSTDIR\et-EE"
SetOutPath "$INSTDIR\et-EE"
File "..\..\..\Dotfuscated\et-EE\PDFEncrypter.resources.dll"
File "..\..\..\helpfile\et-EE\PDF Encrypter Users Manual.chm"
CreateDirectory "$INSTDIR\fa-IR"
SetOutPath "$INSTDIR\fa-IR"
File "..\..\..\Dotfuscated\fa-IR\PDFEncrypter.resources.dll"
File "..\..\..\helpfile\fa-IR\PDF Encrypter Users Manual.chm"
CreateDirectory "$INSTDIR\fi-FI"
SetOutPath "$INSTDIR\fi-FI"
File "..\..\..\Dotfuscated\fi-FI\PDFEncrypter.resources.dll"
File "..\..\..\helpfile\fi-FI\PDF Encrypter Users Manual.chm"
CreateDirectory "$INSTDIR\fr-FR"
SetOutPath "$INSTDIR\fr-FR"
File "..\..\..\Dotfuscated\fr-FR\PDFEncrypter.resources.dll"
File "..\..\..\helpfile\fr-FR\PDF Encrypter Users Manual.chm"
CreateDirectory "$INSTDIR\he-IL"
SetOutPath "$INSTDIR\he-IL"
File "..\..\..\Dotfuscated\he-IL\PDFEncrypter.resources.dll"
File "..\..\..\helpfile\he-IL\PDF Encrypter Users Manual.chm"
CreateDirectory "$INSTDIR\hi-IN"
SetOutPath "$INSTDIR\hi-IN"
File "..\..\..\Dotfuscated\hi-IN\PDFEncrypter.resources.dll"
File "..\..\..\helpfile\hi-IN\PDF Encrypter Users Manual.chm"
CreateDirectory "$INSTDIR\hr-HR"
SetOutPath "$INSTDIR\hr-HR"
File "..\..\..\Dotfuscated\hr-HR\PDFEncrypter.resources.dll"
File "..\..\..\helpfile\hr-HR\PDF Encrypter Users Manual.chm"
CreateDirectory "$INSTDIR\hu-HU"
SetOutPath "$INSTDIR\hu-HU"
File "..\..\..\Dotfuscated\hu-HU\PDFEncrypter.resources.dll"
File "..\..\..\helpfile\hu-HU\PDF Encrypter Users Manual.chm"
CreateDirectory "$INSTDIR\id-ID"
SetOutPath "$INSTDIR\id-ID"
File "..\..\..\Dotfuscated\id-ID\PDFEncrypter.resources.dll"
File "..\..\..\helpfile\id-ID\PDF Encrypter Users Manual.chm"
CreateDirectory "$INSTDIR\is-IS"
SetOutPath "$INSTDIR\is-IS"
File "..\..\..\Dotfuscated\is-IS\PDFEncrypter.resources.dll"
File "..\..\..\helpfile\is-IS\PDF Encrypter Users Manual.chm"
CreateDirectory "$INSTDIR\it-IT"
SetOutPath "$INSTDIR\it-IT"
File "..\..\..\Dotfuscated\it-IT\PDFEncrypter.resources.dll"
File "..\..\..\helpfile\it-IT\PDF Encrypter Users Manual.chm"
CreateDirectory "$INSTDIR\ja-JP"
SetOutPath "$INSTDIR\ja-JP"
File "..\..\..\Dotfuscated\ja-JP\PDFEncrypter.resources.dll"
File "..\..\..\helpfile\ja-JP\PDF Encrypter Users Manual.chm"
CreateDirectory "$INSTDIR\ka-GE"
SetOutPath "$INSTDIR\ka-GE"
File "..\..\..\Dotfuscated\ka-GE\PDFEncrypter.resources.dll"
File "..\..\..\helpfile\ka-GE\PDF Encrypter Users Manual.chm"
CreateDirectory "$INSTDIR\ko-KR"
SetOutPath "$INSTDIR\ko-KR"
File "..\..\..\Dotfuscated\ko-KR\PDFEncrypter.resources.dll"
File "..\..\..\helpfile\ko-KR\PDF Encrypter Users Manual.chm"
CreateDirectory "$INSTDIR\lt-LT"
SetOutPath "$INSTDIR\lt-LT"
File "..\..\..\Dotfuscated\lt-LT\PDFEncrypter.resources.dll"
File "..\..\..\helpfile\lt-LT\PDF Encrypter Users Manual.chm"
CreateDirectory "$INSTDIR\lv-LV"
SetOutPath "$INSTDIR\lv-LV"
File "..\..\..\Dotfuscated\lv-LV\PDFEncrypter.resources.dll"
File "..\..\..\helpfile\lv-LV\PDF Encrypter Users Manual.chm"
CreateDirectory "$INSTDIR\nl-NL"
SetOutPath "$INSTDIR\nl-NL"
File "..\..\..\Dotfuscated\nl-NL\PDFEncrypter.resources.dll"
File "..\..\..\helpfile\nl-NL\PDF Encrypter Users Manual.chm"
CreateDirectory "$INSTDIR\nn-NO"
SetOutPath "$INSTDIR\nn-NO"
File "..\..\..\Dotfuscated\nn-NO\PDFEncrypter.resources.dll"
File "..\..\..\helpfile\nn-NO\PDF Encrypter Users Manual.chm"
CreateDirectory "$INSTDIR\pl-PL"
SetOutPath "$INSTDIR\pl-PL"
File "..\..\..\Dotfuscated\pl-PL\PDFEncrypter.resources.dll"
File "..\..\..\helpfile\pl-PL\PDF Encrypter Users Manual.chm"
CreateDirectory "$INSTDIR\pt-PT"
SetOutPath "$INSTDIR\pt-PT"
File "..\..\..\Dotfuscated\pt-PT\PDFEncrypter.resources.dll"
File "..\..\..\helpfile\pt-PT\PDF Encrypter Users Manual.chm"
CreateDirectory "$INSTDIR\ro-RO"
SetOutPath "$INSTDIR\ro-RO"
File "..\..\..\Dotfuscated\ro-RO\PDFEncrypter.resources.dll"
File "..\..\..\helpfile\ro-RO\PDF Encrypter Users Manual.chm"
CreateDirectory "$INSTDIR\ru-RU"
SetOutPath "$INSTDIR\ru-RU"
File "..\..\..\Dotfuscated\ru-RU\PDFEncrypter.resources.dll"
File "..\..\..\helpfile\ru-RU\PDF Encrypter Users Manual.chm"
CreateDirectory "$INSTDIR\sk-SK"
SetOutPath "$INSTDIR\sk-SK"
File "..\..\..\Dotfuscated\sk-SK\PDFEncrypter.resources.dll"
File "..\..\..\helpfile\sk-SK\PDF Encrypter Users Manual.chm"
CreateDirectory "$INSTDIR\sl-SI"
SetOutPath "$INSTDIR\sl-SI"
File "..\..\..\Dotfuscated\sl-SI\PDFEncrypter.resources.dll"
File "..\..\..\helpfile\sl-SI\PDF Encrypter Users Manual.chm"
CreateDirectory "$INSTDIR\sv-SE"
SetOutPath "$INSTDIR\sv-SE"
File "..\..\..\Dotfuscated\sv-SE\PDFEncrypter.resources.dll"
File "..\..\..\helpfile\sv-SE\PDF Encrypter Users Manual.chm"
CreateDirectory "$INSTDIR\th-TH"
SetOutPath "$INSTDIR\th-TH"
File "..\..\..\Dotfuscated\th-TH\PDFEncrypter.resources.dll"
File "..\..\..\helpfile\th-TH\PDF Encrypter Users Manual.chm"
CreateDirectory "$INSTDIR\tr-TR"
SetOutPath "$INSTDIR\tr-TR"
File "..\..\..\Dotfuscated\tr-TR\PDFEncrypter.resources.dll"
File "..\..\..\helpfile\tr-TR\PDF Encrypter Users Manual.chm"
CreateDirectory "$INSTDIR\uk-UA"
SetOutPath "$INSTDIR\uk-UA"
File "..\..\..\Dotfuscated\uk-UA\PDFEncrypter.resources.dll"
File "..\..\..\helpfile\uk-UA\PDF Encrypter Users Manual.chm"
CreateDirectory "$INSTDIR\vi-VN"
SetOutPath "$INSTDIR\vi-VN"
File "..\..\..\Dotfuscated\vi-VN\PDFEncrypter.resources.dll"
File "..\..\..\helpfile\vi-VN\PDF Encrypter Users Manual.chm"
CreateDirectory "$INSTDIR\zh-CHS"
SetOutPath "$INSTDIR\zh-CHS"
File "..\..\..\Dotfuscated\zh-CHS\PDFEncrypter.resources.dll"
File "..\..\..\helpfile\zh-CHS\PDF Encrypter Users Manual.chm"
 
;write uninstall information to the registry
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_SHORTCUT}" "DisplayName" "${PRODUCT_SHORTCUT} (remove only)"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_SHORTCUT}" "DisplayIcon" "$INSTDIR\${MUI_FILE}.exe"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_SHORTCUT}" "UninstallString" "$INSTDIR\Uninstall.exe"

 ;Store installation folder
  WriteRegStr HKLM "Software\4dots Software\PDFEncrypter" "" $INSTDIR
  WriteRegStr HKLM "Software\4dots Software\PDFEncrypter" "InstallationDirectory" $INSTDIR
 
  WriteUninstaller "$INSTDIR\Uninstall.exe"

  inetc::get /SILENT "http://www.4dots-software.com/dolog/dolog.php?request_file=${PRODUCT_SHORTCUT}" "$PLUGINSDIR\temptmp.txt"  /end
 
SectionEnd
 
 
;--------------------------------    
;Uninstaller Section  
Section "Uninstall"
   SetShellVarContext all

 ${If} ${RunningX64}

  SetRegView 64

!ifndef LIBRARY_X64
  !define LIBRARY_X64
!endif

  !insertmacro UnInstallLib REGDLL NOTSHARED NOREBOOT_NOTPROTECTED $SYSDIR\PDFEncrypterShellExt.dll
  SetRegView 64
   SetShellVarContext all
; 64bit things here

${Else}

; 32bit things here

  !insertmacro UnInstallLib REGDLL NOTSHARED NOREBOOT_NOTPROTECTED $SYSDIR\PDFEncrypterShellExt.dll


${EndIf}  

 ExecWait "$INSTDIR\${MUI_FILE}.exe /uninstall"  

;Delete Files 
  RMDir /r "$INSTDIR\*.*"    

;Remove the installation directory
;  RMDir "$INSTDIR\de-DE"
  RMDir "$INSTDIR"

;Delete Start Menu Shortcuts
  Delete "$DESKTOP\${PRODUCT_SHORTCUT}.lnk"

  Delete "$SMPROGRAMS\${PRODUCT_SHORTCUT}\*.*"
  RmDir  "$SMPROGRAMS\${PRODUCT_SHORTCUT}"
 
;Delete Uninstaller And Unistall Registry Entries
  DeleteRegKey HKEY_LOCAL_MACHINE "SOFTWARE\${PRODUCT_SHORTCUT}"
  DeleteRegKey HKEY_LOCAL_MACHINE "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_SHORTCUT}"  
  DeleteRegKey HKLM "Software\4dots Software\PDFEncrypter"
  DeleteRegKey HKCU "Software\4dots Software\PDFEncrypter"

SetShellVarContext current
 RMDir /r "$PROGRAMFILES\4dots Software\${PRODUCT_SHORTCUT}\*.*"
 RMDir "$PROGRAMFILES\4dots Software\${PRODUCT_SHORTCUT}"

SectionEnd

;--------------------------------    
;MessageBox Section

 
;Function that calls a messagebox when installation finished correctly
Function .onInstSuccess
 ; MessageBox MB_OK "You have successfully installed ${MUI_PRODUCT}. Use the desktop icon to start the program."
FunctionEnd
 
 
Function un.onUninstSuccess
  MessageBox MB_OK "You have successfully uninstalled ${MUI_PRODUCT}."
FunctionEnd

Function .onInit
  !insertmacro INSTALLOPTIONS_EXTRACT "NSISAdditionalActionsPage.ini"
FunctionEnd

Function myGUIInit
  SetShellVarContext all
 StrCpy $INSTDIR "$PROGRAMFILES\4dots Software\${PRODUCT_SHORTCUT}"
FunctionEnd

; Usage
; Define in your script two constants:
;   DOT_MAJOR "(Major framework version)"
;   DOT_MINOR "{Minor framework version)"
;   DOT_MINOR_MINOR "{Minor framework version - last number after the second dot)"
; 
; Call IsDotNetInstalledAdv
; This function will abort the installation if the required version 
; or higher version of the .NET Framework is not installed.  Place it in
; either your .onInit function or your first install section before 
; other code.
Function IsDotNetInstalledAdv
   Push $0
   Push $1
   Push $2
   Push $3
   Push $4
   Push $5
 
  StrCpy $0 "0"
  StrCpy $1 "SOFTWARE\Microsoft\.NETFramework" ;registry entry to look in.
  StrCpy $2 0
 
  StartEnum:
    ;Enumerate the versions installed.
    EnumRegKey $3 HKLM "$1\policy" $2
 
    ;If we don't find any versions installed, it's not here.
    StrCmp $3 "" noDotNet notEmpty
 
    ;We found something.
    notEmpty:
      ;Find out if the RegKey starts with 'v'.  
      ;If it doesn't, goto the next key.
      StrCpy $4 $3 1 0
      StrCmp $4 "v" +1 goNext
      StrCpy $4 $3 1 1
 
      ;It starts with 'v'.  Now check to see how the installed major version
      ;relates to our required major version.
      ;If it's equal check the minor version, if it's greater, 
      ;we found a good RegKey.
      IntCmp $4 ${DOT_MAJOR} +1 goNext yesDotNetReg
      ;Check the minor version.  If it's equal or greater to our requested 
      ;version then we're good.
      StrCpy $4 $3 1 3
      IntCmp $4 ${DOT_MINOR} +1 goNext yesDotNetReg
 
      ;detect sub-version - e.g. 2.0.50727
      ;takes a value of the registry subkey - it contains the small version number
      EnumRegValue $5 HKLM "$1\policy\$3" 0
 
      IntCmpU $5 ${DOT_MINOR_MINOR} yesDotNetReg goNext yesDotNetReg
 
    goNext:
      ;Go to the next RegKey.
      IntOp $2 $2 + 1
      goto StartEnum
 
  yesDotNetReg: 
    ;Now that we've found a good RegKey, let's make sure it's actually
    ;installed by getting the install path and checking to see if the 
    ;mscorlib.dll exists.
    EnumRegValue $2 HKLM "$1\policy\$3" 0
    ;$2 should equal whatever comes after the major and minor versions 
    ;(ie, v1.1.4322)
    StrCmp $2 "" noDotNet
    ReadRegStr $4 HKLM $1 "InstallRoot"
    ;Hopefully the install root isn't empty.
    StrCmp $4 "" noDotNet
    ;build the actuall directory path to mscorlib.dll.
    StrCpy $4 "$4$3.$2\mscorlib.dll"
    IfFileExists $4 yesDotNet noDotNet
 
  noDotNet:
    ;Nope, something went wrong along the way.  Looks like the 
    ;proper .NET Framework isn't installed.  
 
    ;Uncomment the following line to make this function throw a message box right away 
   MessageBox MB_OK "You must have v${DOT_MAJOR}.${DOT_MINOR}.${DOT_MINOR_MINOR} or greater of the .NET Framework installed.$\n$\nPlease download and install the .NET Redistributable from the Webpage that will open and run ${MUI_FILE}Setup.exe once again !"

  ${If} ${RunningX64}

	ExecShell "open" "http://www.microsoft.com/downloads/details.aspx?FamilyID=b44a0000-acf8-4fa1-affb-40e78d788b00"
  ${Else}

	ExecShell "open" "http://www.microsoft.com/downloads/details.aspx?FamilyID=0856eacb-4362-4b0d-8edd-aab15c5e04f5"
  ${EndIf}  




    Abort
     StrCpy $0 0
     Goto done
 
     yesDotNet:
    ;Everything checks out.  Go on with the rest of the installation.
    StrCpy $0 1
 
   done:
     Pop $4
     Pop $3
     Pop $2
     Pop $1
     Exch $0
 FunctionEnd

Function OptionsPage

  ; Prepare shortcut page with default values
  !insertmacro MUI_HEADER_TEXT "Additional Options" "Please select, whether shortcuts should be created."

  ; Display shortcut page
  !insertmacro INSTALLOPTIONS_DISPLAY_RETURN "NSISAdditionalActionsPage.ini"
  pop $R0 

  ${If} $R0 == "cancel"
    Abort
  ${EndIf} 

  ; Get the selected options

  ReadINIStr $R1 "$PLUGINSDIR\NSISAdditionalActionsPage.ini" "Field 2" "State"
  ReadINIStr $R2 "$PLUGINSDIR\NSISAdditionalActionsPage.ini" "Field 3" "State"
  ReadINIStr $R3 "$PLUGINSDIR\NSISAdditionalActionsPage.ini" "Field 4" "State"

  ${If} $R1 == "1"  
    Call AddStartMenu
  ${EndIf}

  ${If} $R2 == "1"  
   Call AddDesktopShortcut
  ${EndIf}  

  ${If} $R3 == "1"  
   Call IntegrateWindowsExplorer
  ${EndIf}  


FunctionEnd

Function .onGUIEnd
  Delete $INSTDIR\vcredist_x64.exe
  Delete $INSTDIR\vcredist_x86.exe

FunctionEnd

Function OpenWebpageFunction
  ExecShell "" "http://www.pdfdocmerge.com/pdfencrypter/?afterinstall=true"
FunctionEnd

;eof