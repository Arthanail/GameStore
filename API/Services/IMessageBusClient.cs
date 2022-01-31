using API.Dtos;

namespace API.Services
{
    public interface IMessageBusClient
    {
        public void PublishedNewGame(PublishedGameDto publishedGameDto);
    }
}