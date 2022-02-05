using MediatR;

namespace API.Commands
{
    public record DeleteGameCommand(int Id) : IRequest<bool>;
}