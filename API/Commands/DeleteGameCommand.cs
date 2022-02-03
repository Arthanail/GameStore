using System;
using MediatR;

namespace API.Commands
{
    public class DeleteGameCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeleteGameCommand(Guid id)
        {
            Id = id;
        }
    }
}