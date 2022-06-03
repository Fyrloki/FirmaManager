# FirmaManager
For manage people, for example workerlist oder clients

Im 10 Client finden sie das appsettings.json, dort müssen sie den Connectionstring anpassen, für Ihren Server.

Beispiel 1: Bei mir (Basil Döring) hatte ich folgenden Connectionstring
Server=.\\MSSQLSERVER2017;Database=DieFirma;Trusted_Connection=True; Connection Timeout = 1;

Beispiel 2: Bei meinem Kollegen (Linus Oberli) war dieser folgend:
Server=.\\;Database=DieFirma;Trusted_Connection=True; Connection Timeout = 1;

Das Script um die Datenbank zu erstellen ist im Ordner SQLScript. 

Diese zwei Punkte müssen gemacht werden, damit der FirmaManager läuft. Der FirmaManager hat eine Datenbank.
Der FirmaManager habe ich (Basil) schon im Geschäft gemacht, haben aber das UI als Winforms gemacht und haben das UI 
jetzt durch ein Wpf-UI ersetzt (Roland Bucher hat das OK dafür gegeben).