using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Game
    {
        [Key]
        [Required]
        public Guid Id { get; private set; }
        [Required]
        public string Title { get; private set; }
        [Required]
        public string DevelopmentStudio { get; private set; }
        [Required]
        public string GameGenre { get; private set; }

        private Game()
        {
            
        }
        public Game(string title, string developmentStudio, string gameGenre)
        {
            Title = title;
            DevelopmentStudio = developmentStudio;
            GameGenre = gameGenre;
        }

    }
}