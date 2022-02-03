using System.Collections.Generic;
using API.Dtos;
using MediatR;

namespace API.Queries
{
    public class GetGamesQuerie : IRequest<IEnumerable<ReadGameDto>>
    {
        
    }
}