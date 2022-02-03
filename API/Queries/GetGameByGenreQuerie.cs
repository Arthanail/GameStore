using System.Collections.Generic;
using API.Dtos;
using MediatR;

namespace API.Queries
{
    public class GetGameByGenreQuerie : IRequest<IEnumerable<ReadGameDto>>
    {
        public string Genre { get; }

        public GetGameByGenreQuerie(string genre)
        {
            Genre = genre;
        }
    }
}