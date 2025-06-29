using website101.dtos;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

const string GetGameEndpointName = "GetGame";

List<Data> games = [
    new(1, "Halo", "Shooter", 59.99m, new DateOnly(2021, 11, 15)),
    new(2, "FIFA", "Sports", 69.99m, new DateOnly(2021, 8, 10)),
    new(3, "Minecraft", "Sandbox", 29.99m, new DateOnly(2021, 7, 15)),
    new(4, "Fortnite", "Battle Royale", 0.00m, new DateOnly(2021, 5, 15)),
    new(5, "Among Us", "Social Deduction", 4.99m, new DateOnly(2021, 3, 15)),
    new(6, "Valorant", "Shooter", 0.00m, new DateOnly(2021, 10, 15)),
    new(7, "League of Legends", "MOBA", 0.00m, new DateOnly(2021, 6, 15)),
    new(8, "World of Warcraft", "MMORPG", 14.99m, new DateOnly(2021, 8, 15)),
    new(9, "Overwatch", "Shooter", 19.99m, new DateOnly(2021, 2, 15)),
    new(10, "Rocket League", "Sports", 0.00m, new DateOnly(2021, 1, 15))
];

app.MapGet("/", () => "Hello World!");

//Get /games
app.MapGet("games", () => games);

//Get /games/1
app.MapGet("games/{id}", (int id) =>
{
    Data? game = games.Find(game => game.id == id);

    return game is null ? Results.NotFound() : Results.Ok(game);
})
.WithName(GetGameEndpointName);

//Post /games
app.MapPost("games", (Create newGame) =>
{
    Data game = new(
        games.Count + 1,
        newGame.name,
        newGame.genre,
        newGame.price,
        newGame.releaseDate
        );

    games.Add(game);

    return Results.CreatedAtRoute(GetGameEndpointName,
    new { id = game.id },
    game);
});


//Put /games/1
app.MapPut("games/{id}", (int id, Update updatedGame) =>
{
    var index = games.FindIndex(game => game.id == id);

    games[index] = new Data(
        id,
        updatedGame.name,
        updatedGame.genre,
        updatedGame.price,
        updatedGame.releaseDate
        );
    return Results.Accepted();
});


//DELETE /games/1
app.MapDelete("games/{id}", (int id) =>
{
    games.RemoveAll(game => game.id == id);
    return Results.Accepted();
});
app.Run();
