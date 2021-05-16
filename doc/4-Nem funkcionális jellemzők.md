# Nem-funkcionális jellemzők vizsgálata

A Benchmarkdotnet (https://github.com/dotnet/BenchmarkDotNet) segítségével teszteltem néhány függvény teljesítményét.

A fügvények futtatásához szükséges változókat a RDFSharpBenchmark osztály konstruktorában hoztam létre. Minden tesztelt függvénynek megmérte az átlagos futási ideját és azt is, hogy melyik mennyi memmóriát használ, ezeket a futtatás végén a következő táblázatban jeleníti meg számunkra.
![image](https://user-images.githubusercontent.com/61654674/118411463-00848800-b695-11eb-8d62-68ce5f46ed5f.png)

Ezek a tesztek jól használhatóak egy-egy függvény optimalizálásának segítésére gyorsaság és memóriaigény szempontjából is.
Illetve ha egy feladatra két megoldásunk van akkor ezek teljesítményének az összehasonlítására is alkalmas.
