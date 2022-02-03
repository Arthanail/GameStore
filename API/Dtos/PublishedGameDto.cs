using System;

namespace API.Dtos
{
    public class PublishedGameDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Event { get; set; }
    }
}