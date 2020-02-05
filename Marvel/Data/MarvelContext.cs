using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marvel.Api.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Marvel.Data
{
    public class MarvelContext: DbContext
    {
        public MarvelContext(DbContextOptions<MarvelContext> options): base(options)
        {
        }

        public DbSet<Character> Characters { get; set; }
    }
}
