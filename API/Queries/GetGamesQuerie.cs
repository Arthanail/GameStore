using System.Collections.Generic;
using API.Dtos;
using MediatR;

namespace API.Queries
{
    public record GetGamesQuerie : IRequest<IEnumerable<ReadGameDto>>
    {
        
    }
}