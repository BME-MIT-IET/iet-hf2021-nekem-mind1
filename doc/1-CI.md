# CI beüzemelése

Felelős: Tóth Bence

CI eszköznek a GitHub Actions-t választottam. A projektünk felépítése viszonylag egyszerű, így a CI beüzemelést sem szerettem volna túlbonyolítani. A GitHub által ajánlott .NET workflowt használtam. Elsőre sikeres volt a build, így elkezdtük a munkát a projekttel.

Vasárnap déltől a GitHub Actions [nem működött megfelelően](https://www.githubstatus.com/incidents/zbpwygxwb3gw), valószínűleg a GitHub részéről volt probléma, ugyanis több helyről érkeztek visszajelzések ezzel kapcsolatban. A workflowk queued állapotban maradtak és nem futottak le, a GitHub vizsgálja a problémát (12:20).
