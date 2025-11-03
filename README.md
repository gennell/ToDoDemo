# ToDoDemo

Pobieramy kod ze strony github i wypakowujemy.

Do zbudowania aplikacji wymagane są:
.NET 9 SDK,
aktualny Node.js,
Angular CLI (`npm install -g @angular/cli@20`)

w celu instalacji niezbędnych zależności przechodzimy do folderu:

"\ToDoList.API\client"

i wykonujemy polecenie 

npm install

następnie budujemy aplikację poleceniem

ng build

po zbudowaniu aplikacji powstanie folder wwwroot w katalogu API

następnie przechodzimy do katalogu 

\ToDoList.API\ToDoList.API

i wykonujemy 

dotnet publish -c Release -o ./bin/Publish

Nie trzeba hostować aplikacji.
Aby ją przetestować wystarczy przejść do folderu 

\ToDoList.API\ToDoList.API\bin\Publish

i wykonać ToDoList.API.exe
