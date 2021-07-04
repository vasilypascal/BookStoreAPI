﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAPI.Models
{
    public class BookDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public short Rating { get; set; }
    }
}
