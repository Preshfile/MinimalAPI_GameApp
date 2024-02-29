using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Dtos;

public record GameDto(
    int Id,
    string Name,
    string Genre,
    decimal Price,
    DateTime ReleasedDate,
    string ImageUrl
);

public record CreateGameDto(
    [Required] [StringLength(20)] string Name,
    [Required] string Genre,
    [Range(1, 100)] decimal Price,
    DateTime ReleasedDate,
    [Url][StringLength(100)] string ImageUrl
);

public record UpdateGameDto(
    [Required][StringLength(20)] string Name,
    [Required] string Genre,
    [Range(1, 100)] decimal Price,
    DateTime ReleasedDate,
    [Url][StringLength(100)] string ImageUrl
);