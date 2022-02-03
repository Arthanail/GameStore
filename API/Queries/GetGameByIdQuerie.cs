using System;
using API.Dtos;
using MediatR;

namespace API.Queries
{
    public class GetGameByIdQuerie : IRequest<ReadGameDto>
    {
        public Guid Id { get; }

        public GetGameByIdQuerie(Guid id)
        {
            Id = id;
        }
    }
}