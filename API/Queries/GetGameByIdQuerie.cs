using API.Dtos;
using MediatR;

namespace API.Queries
{
    public record GetGameByIdQuerie(int Id) : IRequest<ReadGameDto>;
}