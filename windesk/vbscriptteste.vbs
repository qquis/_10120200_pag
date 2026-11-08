Dim wShell
Dim i
Dim dteWait
Set wShell = CreateObject("WScript.Shell")

wShell.Run "https://erp.bluesoft.com.br/oxan/seguranca/login/login.action"

dteWait = DateAdd("s", 10, Now())
Do Until (Now() > dteWait)
Loop


WShell.SendKeys "Elias"
WShell.SendKeys "{TAB}"
WShell.SendKeys "!28jesusbom"
WShell.SendKeys "{TAB}"
WShell.SendKeys "{ENTER}"

dteWait = DateAdd("s", 10, Now())
Do Until (Now() > dteWait)
Loop

For i = 1 To 5
WShell.SendKeys "{TAB}"
Next

WShell.SendKeys "{ENTER}"

dteWait = DateAdd("s", 10, Now())
Do Until (Now() > dteWait)
Loop

For i = 1 To 18
WShell.SendKeys "{TAB}"
Next

WShell.SendKeys "{ENTER}"

dteWait = DateAdd("s", 10, Now())
Do Until (Now() > dteWait)
Loop

For i = 1 To 62
WShell.SendKeys "{TAB}"
Next

WShell.SendKeys "{ENTER}"