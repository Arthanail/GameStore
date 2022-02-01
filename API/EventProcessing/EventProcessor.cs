using System;
using System.Text.Json;
using API.Dtos;
using AutoMapper;

namespace API.EventProcessing
{
    public class EventProcessor : IEventProcessor
    {
        private readonly IMapper _mapper;

        public EventProcessor(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void ProcessEvent(string message)
        {
            var eventType = DetermineEvent(message);
            switch (eventType)
            {
                case EventType.PublishedGame:
                    Console.WriteLine("--> Platform Published");
                    break;
            }
        }

        private EventType DetermineEvent(string notificationMessage)
        {
            Console.WriteLine("--> Determining Event");

            var eventType = JsonSerializer.Deserialize<EventDto>(notificationMessage);

            switch (eventType.Event)
            {
                case "Game_Published":
                    Console.WriteLine("--> Game Published Event");
                    return EventType.PublishedGame;
                default:
                    Console.WriteLine("--> Not determine this EventType");
                    return EventType.Undetermined;
            }
        }

        enum EventType
        {
            PublishedGame,
            Undetermined
        }
    }
}