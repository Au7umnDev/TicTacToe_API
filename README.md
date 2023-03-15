# TicTacToe API

REST API для игры в крестики-нолики. Endpoints:

* GET api/games: Получить список всех игр.
* GET api/games/{id}: Получить информацию о конкретной игре по ее id.
* POST api/games: Создать новую игру.
* PUT api/games/{id}: Сделать ход в игре по ее id.

## Требования
Для того, чтобы использовать или редактировать данное API по своему усмотрению, потребуется:

* ASP.NET Core 6.0 SDK
* Visual Studio 2022
* SQL Server 2022
* SQL Server Management Studio 2019 (Optional)

## Установка

Чтобы установить и запустить API, необходимо сделать следующее:

1. Скопируйте репозиторий на свой ПК.
2. Откройте TicTacToe_API.sln в Visual Studio.
3. Build > Build Solution.
4. Debug > Start Debugging, или просто нажмите F5.

Стоит отметить, что в данном решении поддерживается Swagger, который позволит самостоятельно опробовать запросы.

## Endpoints

### GET api/games

Возвращает список всех игр.

Example Request:

`GET https://localhost:5001/api/games`

Example Response:

```[
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
```

### GET api/games/{id}

Возвращает конкретную игру по ее id.

Example Request:

`GET https://localhost:5001/api/games/25`

Example Response:

```
{
  "id": 25,
  "player1Id": "A",
  "player2Id": "V",
  "currentTurn": "",
  "winnerId": "A",
  "isDraw": false
}
```

### POST api/games

Создает новую игру.

Example Request:

` POST https://localhost:5001/api/games `

Content-Type: application/json

```
{
    "player1Id": "player1",
    "player2Id": "player2"
}
```

Example Response

```
{
  "id": 26,
  "player1Id": "player1",
  "player2Id": "player2",
  "currentTurn": "player1",
  "winnerId": null,
  "isDraw": false
}
```

### PUT api/games/{id}

Далает ход в конкретной игре по ее id.

Example Request

`PUT https://localhost:5001/api/games/26`

Content-Type: application/json

```
{
    "player": "player1",
    "row": 1,
    "column": 1
}
```

Example Response

`Made a move!`

### GET api/games/{gameId}/Moves

Возвращает все ходы в конкретной игре по ее id.

Example Request

`GET https://localhost:5001/api/games/25/Moves`

Example Response

```
[
  {
    "id": 90,
    "gameId": 25,
    "row": 0,
    "column": 0,
    "player": "A"
  },
  {
    "id": 91,
    "gameId": 25,
    "row": 1,
    "column": 0,
    "player": "V"
  },
  {
    "id": 92,
    "gameId": 25,
    "row": 0,
    "column": 1,
    "player": "A"
  },
  {
    "id": 93,
    "gameId": 25,
    "row": 1,
    "column": 1,
    "player": "V"
  },
  {
    "id": 94,
    "gameId": 25,
    "row": 0,
    "column": 2,
    "player": "A"
  }
]
```

### GET api/games/{gameId}/Moves/{id}

Возвращает конкретный ход в конкретной игре по id игры и id хода.

Example Request

`GET https://localhost:5001/api/games/25/Moves/94`

Example Response

```
{
  "id": 94,
  "gameId": 25,
  "row": 0,
  "column": 2,
  "player": "A"
}
```
## Принцип работы:

Игроки могут создавать игры и, соответственно, ходить в них. Последовательность ходов реализована с помощью поля currentTurn, в который записывается имя игрока, который должен ходить. Каждый ход игра проверяет, появился ли победитель, или же игра закончилась ничьей. В качестве БД используется MS SQL.

## Куда еще лучше?

* Реализовать механизм, по которому один игрок не сможет никаким образом походить за другого, отправляя PUT запросы с нужными body.

## Разработано с помощью:

* [ASP.NET Core 6.0](https://dotnet.microsoft.com)
* [SQL Server 2022 + SQL SMS 19](https://learn.microsoft.com/en-us/sql/ssms/sql-server-management-studio-ssms?view=sql-server-ver16)
