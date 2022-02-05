using System.Collections.Generic;
using API.Dtos;
using MediatR;

namespace API.Queries
{
    public record GetGameByGenreQuerie(string Genre) : IRequest<IEnumerable<ReadGameDto>>;
}