﻿namespace MusicClub.DbCore
{
    public class Act
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Title { get; set; }

        public int? ImageId { get; set; }
        public Image? Image { get; set; }

        public required DateTime Created { get; set; }
        public required DateTime Updated { get; set; }


        public IList<Performance> Performances { get; set; } = [];


        public IList<Job> Jobs { get; set; } = [];


        public required int LineupId { get; set; }
        public Lineup? Lineup { get; set; }
    }
}