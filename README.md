# TicTacToe API

Это RESTful API для игры в крестики-нолики. Endpoints:

* GET api/games: Получить список всех игр.
* GET api/games/{id}: Получить информацию о конкретной игре по ее id.
* POST api/games: Создать новую игру.
* PUT api/games/{id}: Сделать ход в игре по ее id.

## Требования
Для того, чтобы использовать или редактировать данное API по своему усмотрению, потребуется:

* ASP.NET Core 6.0 SDK
* Visual Studio 2022

## Установка

Чтобы установить и запустить API, необходимо сделать следующее:

Скопируйте репозиторий на свой ПК.
Откройте TicTacToe_API.sln в Visual Studio.
Build > Build Solution.
Debug > Start Debugging, или просто нажмите F5.

Стоит отметить, что в данном решении поддерживается Swagger, который позволит самостоятельно опробовать запросы.

## Endpoints

### GET api/games

Возвращает список всех игр.

Example Request:

GET https://localhost:5001/api/games

Example Response:

[
  {
    "id": 24,
    "player1Id": "A",
    "player2Id": "V",
    "currentTurn": "",
    "winnerId": null,
    "isDraw": true
  },
  {
    "id": 25,
    "player1Id": "A",
    "player2Id": "V",
    "currentTurn": "",
    "winnerId": "A",
    "isDraw": false
  }
]

### GET api/games/{id}

Возвращает конкретную игру по ее id.

Example Request:

GET https://localhost:5001/api/games/25

Example Response:

{
  "id": 25,
  "player1Id": "A",
  "player2Id": "V",
  "currentTurn": "",
  "winnerId": "A",
  "isDraw": false
}

### POST api/games

Создает новую игру.

Example Request:

POST https://localhost:5001/api/games

Content-Type: application/json

{
    "player1Id": "player1",
    "player2Id": "player2"
}

Example Response

{
  "id": 26,
  "player1Id": "player1",
  "player2Id": "player2",
  "currentTurn": "player1",
  "winnerId": null,
  "isDraw": false
}

### PUT api/games/{id}

Далает ход в конкретной игре по ее id.

Example Request

PUT https://localhost:5001/api/games/26

Content-Type: application/json

{
    "player": "player1",
    "row": 1,
    "column": 1
}

Example Response

Made a move!

## Разработано с помощью [ASP.NET Core 6.0](https://dotnet.microsoft.com)
