# Project Audit – DecideBetter
Author: Altina Islami
Date: April 2026cd

1. Përshkrimi i shkurtër i projektit

DecideBetter është një aplikacion web i bazuar në Multi-Criteria Decision Analysis (MCDA), i cili ndihmon përdoruesit të marrin vendime më të strukturuara dhe objektive duke krahasuar opsione të ndryshme sipas kritereve të personalizuara.

Çka bën sistemi?

Sistemi lejon përdoruesit të:

1.Krijojnë një vendim (decision)
2.Shtojnë alternativa (options)
3.definojnë kritere (criteria)
4.caktojnë peshë për secilin kriter
5.shohin rezultatin final bazuar në kalkulim

Kush janë përdoruesit kryesorë?

1.Studentë (p.sh. zgjedhje universiteti)
2.Persona që krahasojnë produkte (laptop, telefon, etj.)
3.Profesionistë që marrin vendime strategjike

Funksionaliteti kryesor

1.Krijimi i vendimeve
2.Menaxhimi i kritereve dhe peshave
3.Kalkulimi i rezultateve
4.Shfaqja e opsionit më të mirë

2. Çka funksionon mirë?

1.Struktura bazë e projektit është funksionale
2.Projekti ka ndarje në shtresa (p.sh. Models, Data, UI), që është një praktikë e mirë.
3.Implementimi i CRUD operacioneve
4.Krijimi, leximi, përditësimi dhe fshirja e të dhënave funksionon siç duhet.
5.Ideja e projektit është shumë e qartë dhe e dobishme
6.MCDA është një problem real dhe aplikimi e zgjidh atë në mënyrë praktike.
7.Përdorimi i repository pattern
8.Ndihmon në organizimin e kodit dhe e bën më të lehtë mirëmbajtjen.

3. Dobësitë e projektit

Mungon ndarje e qartë në Service layer.
Mungesë e validimit të inputeve
Nuk kontrollohet nëse:
Peshat janë valide (p.sh. >100%)
Fushat janë bosh
inputet janë numerik
Nuk trajtohen gabimet (exceptions) në mënyrë të kontrolluar.
Aplikacioni mund të crash-ojë në raste të caktuara.
Flow i përdoruesit nuk është shumë intuitiv.
Mund të mungojnë udhëzime ose feedback për përdoruesin.
Nuk shpjegohet mjaftueshëm si funksionon sistemi.
Mungojnë shembuj përdorimi.
Përdorimi i file/database është i thjeshtë
Mund të përdoret vetëm file storage pa strukturë të fortë.
Nuk ka optimizim për të dhëna më të mëdha.

4. 3 përmirësime që do t’i implementoj

🔧 Përmirësimi 1: Validimi i inputeve
Problemi:
Nuk ka kontroll për inpute të pavlefshme (p.sh. peshat > 100%, fusha bosh).
Zgjidhja:
Implementimi i validimit në:
UI (form validation)
Backend (business logic)
Pse ka rëndësi:
Parandalon gabime në kalkulim
Rrit besueshmërinë e aplikacionit
Përmirëson eksperiencën e përdoruesit

🔧 Përmirësimi 2: Shtimi i Service Layer (ndarje më e mirë e arkitekturës)
Problemi:
Logjika e biznesit është e përzier me UI ose repository.
Zgjidhja:
Krijimi i një shtrese të re:
DecisionService
CalculationService
Pse ka rëndësi:
Kod më i organizuar dhe i pastër
Më i lehtë për testim
Më i mirë për zgjerim në të ardhmen

🔧 Përmirësimi 3: Error Handling (trajtim i gabimeve)
Problemi:
Nuk trajtohen gabimet si:
null values
file not found
invalid operations
Zgjidhja:
Përdorimi i try-catch
Krijimi i mesazheve të qarta për përdoruesin
Logging i gabimeve
Pse ka rëndësi:
Parandalon crash të aplikacionit
Ndihmon në debugging
Rrit stabilitetin e sistemit

5. Një pjesë që ende nuk e kuptoj plotësisht

Një pjesë që ende nuk e kuptoj plotësisht është ndarja e saktë e përgjegjësive ndërmjet Repository dhe Service Layer.

Konkretisht:

Kur duhet të vendoset logjika në repository dhe kur në service?
Si të dizajnohet një arkitekturë që është scalable dhe maintainable?

Kjo është e rëndësishme sepse ndikon drejtpërdrejt në:

strukturën e projektit
mirëmbajtjen
zgjerimin në të ardhmen