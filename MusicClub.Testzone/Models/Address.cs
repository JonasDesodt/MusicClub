﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicClub.Testzone.Models
{
    public class Address
    {
        public int Id { get; set; }

        public required int PersonId { get; set; }

        public int? JobId { get; set; }
    }
}
