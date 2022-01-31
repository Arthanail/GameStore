namespace API.Dtos
{
    public class UpdateGameDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string DevelopmentStudio { get; set; }
        public string GameGenre { get; set; }
    }
}