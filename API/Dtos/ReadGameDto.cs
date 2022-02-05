namespace API.Dtos
{
    public record ReadGameDto
    {
        public int Id { get; init; }
        public string Title { get; init; }
        public string DevelopmentStudio { get; init; }
        public string GameGenre { get; init; }
    }
}