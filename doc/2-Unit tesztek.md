# Unit tesztek

A unit teszteléshez létrehoztam egy külön xUnit projektet, ami a különböző osztályok vizsgálásához használt teszt-osztályokat tartalmazza, valamint egy statikus "TestModelObject" osztályt, ami a teszteléshez szükséges környezetet és dummy adatokat szolgáltatja.

![image](https://user-images.githubusercontent.com/60943914/118410898-19d80500-b692-11eb-89ad-259279d46402.png)


A tesztek az RDFSharp.Model könyvtár osztályaira íródtak, azon belül is főleg az RDFGraph osztály függvényeire, de készült az RDFResource-ra és az RDFTriple-re is.

A tesztek egyenkénti felépítése a következő:

• A TestModelObject segítségével létrehozzuk a kiinduló tesztkörnyezetet,

• Alapvető egyszerű műveletekkel a tesztkörnyezetben elmentjük a tesztelni kívánt függvény elvárt működésének az eredményét.

• Egy másik változóban elmentjük a tesztkörnyezetből kiindulva a tényleges függvény visszatérési értékét.

• Assert-el megvizsgáljuk az eredményeket, hogy a kívánt eredmény megfelel-e a kapott eredménynek.

![image](https://user-images.githubusercontent.com/60943914/118411126-55bf9a00-b693-11eb-937a-1fab67db88a3.png)

Smodics Roland(V4UL2C)
