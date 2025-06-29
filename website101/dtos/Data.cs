namespace website101.dtos;

public record class Data(
    int id,
    string name,
    string genre,
    decimal price,
    DateOnly releaseDate
    );