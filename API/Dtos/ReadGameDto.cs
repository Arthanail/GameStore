﻿using System;

namespace API.Dtos
{
    public class ReadGameDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string DevelopmentStudio { get; set; }
        public string GameGenre { get; set; }
    }
}