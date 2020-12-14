Az IRF beadandó leírása

A projekt célja az, hogy e-könnyveket tudjunk hatékonyan nyilvántartani. A program így 2 funkcióval bír: 
	- a rekordok adatbázisba mentése
	- keresés az adatbázisrekordok alapján, valamint a keresés eredményének ábrázolása listaszerűen és grafikusan
	
	
Az adatbázis:
	- lokális adatbázis, egy táblából áll
	- az egyes rekordok (e-könyvek) rendelkeznek 	-> egyedi azonosítóval
													-> címmel
													-> szerzővel
													-> formátummal

Rekordok mentése az adatbázisba:
	- ki kell töltenünk a megadott mezőket, valamint ki kell választanunk a formátumot
	- ha végeztünk, akkor az "ADD" gombbal regisztrálhatjuk az adott e-könyvet
	- minden mezőt szükséges kitölteni
	

Keresés és megjelenítés:
	- Az adatbázisrekordok között a keresőmező segítségével kereshetünk
	- A keresés alapjáraton címre irányul, de ezt szabadon átállíthatjuk az "Author" kiválasztásával
	- A haladó kereséshez használhatjuk a "*" karaktert, ami bármennyi karaktert helyettesíthet bármilyen mennyiségben
	- Az "OK" gomb megnyomása után láthatjuk a keresés eredményét	-> listaszerűen a bal alsó mezőben
																	-> grafikusan az egyes formátumok számosságát megjelenítve
																	
																
Példa:
	- Az adatbázis úgy lett feltöltve, hogy a program minden funkcióját kipróbálhassuk (10 rekord)
	- A "*star" kulcsszó minden rekordot kiad, aminek az utolsó 4 karaktere "star" (0/10 rekord)
	- A "star*" kulcsszó olyan rekordokat eredményez, amelyeknek az első 4 karaktere "star" (1/10 rekord)
	- A "star" kulcsszó azokat a reordokat adja ki, amelyben önállóan szerepel a "star" karaktersorozat (1/10 rekord)
	- A "*star*" kulcsszó minden rekordot kiad, amelyben fellelhető a "star" karaktersorozat (6/10 rekord)
	- Az "*s*t*" kulcsszó minden olyan rekordot visszaad, amelyben megtalálható az "s" és később egy "t" is (7/10 rekord)