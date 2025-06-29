namespace website101.dtos;

public record class Update
(
    string name,
    string genre,
    decimal price,
    DateOnly releaseDate
    );