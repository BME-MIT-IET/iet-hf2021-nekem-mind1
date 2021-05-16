# CI beüzemelése

CI eszköznek a GitHub Actions-t választottam. A projektünk felépítése viszonylag egyszerű, így a CI beüzemelést sem szerettem volna túlbonyolítani. A GitHub által ajánlott .NET workflowt használtam. Elsőre sikeres volt a build, így elkezdtük a munkát a projekttel.

Vasárnap déltől a GitHub Actions [nem működött megfelelően](https://www.githubstatus.com/incidents/zbpwygxwb3gw), valószínűleg a GitHub részéről volt probléma, ugyanis több helyről érkeztek visszajelzések ezzel kapcsolatban. A workflowk queued állapotban maradtak és nem futottak le, a GitHub vizsgálja a problémát (12:20).

Délutánra/estére a probléma megoldódott, így be tudtam fejezni a workflow létrehozását, hibáinak kijavítását.

A CI beüzemelésen kívül a pull requestek kezelésével foglalkoztam. Code review és merge után a main branchen lévő projekten végeztem apróbb módosításokat.

![Screenshot 2021-05-16 at 23 10 05](https://user-images.githubusercontent.com/48957481/118412724-e00bfc00-b69b-11eb-9fa9-7d906edbc6ab.jpg)

Tóth Bence József (D7J63D)
