using Game.Application;
using Game.Starter;

var firstPlayer = new SimplePlayer();
var secondPlayer = new SimplePlayer();
var field = new GameFieldFactory().CreateGameField(firstPlayer, secondPlayer);

var game = new TwoPlayersGame(field, firstPlayer, secondPlayer);