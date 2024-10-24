﻿using MusicClub.Dto.Attributes;

namespace MusicClub.Dto.Filters.Requests
{
    [GenerateFilterResult]
    public class ActFilterRequest : Sort//, IFilterRequestConverter<ActFilterResult>
    {
        public string? Name { get; set; }

        public string? Title { get; set; }

        public DateTime? Start { get; set; }

        [Min(0)]
        public int? Duration { get; set; }

        [Min(1)]
        public int? LineupId { get; set; }

        [Min(1)]
        public int? ImageId { get; set; }

        //public string ToQueryString()
        //{
        //    return ActFilterRequestExtensions.ToQueryString(this);
        //}

        //public ActFilterResult ToResult()
        //{
        //    return ActFilterRequestExtensions.ToResult(this);
        //}
    }
}
