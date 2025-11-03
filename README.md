# ToDoDemo

Dla uproszczenia instalacji i testowania aplikacja używa jako bazy Sqlite
dodano mechanizm notyfikacji na dzień przed terminem.
w interwale 1 godzinnym sprawdzane jest czy są zadania nieskończone z terminem na dzień przyszły
dla takich zadań jest wysyłany na przypisany do zadania email.
powiadomienie wysyłane jest raz, modyfikacja zadania powoduje ponowne wysłanie powiadomienia.

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

w pliku appsettings.json w sekcji EmailSettings
są ustawienia potrzebne do wysyłania notyfikacji na poczte email

po zapisaniu ustawień należy wykonać ToDoList.API.exe

aplikacja dostępna jest w przeglądarce pod adresem http://localhost:5000/
