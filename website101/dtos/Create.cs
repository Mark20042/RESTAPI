namespace website101.dtos;

public record class Create(
    string name,
    string genre,
    decimal price,
    DateOnly releaseDate
    );
