using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Campeonato2019.Models;

namespace Campeonato2019.Data
{
    public class Campeonato2019Context : DbContext
    {
        public Campeonato2019Context (DbContextOptions<Campeonato2019Context> options)
            : base(options)
        {
        }

        public DbSet<Campeonato2019.Models.Atleta> Atleta { get; set; }

        public DbSet<Campeonato2019.Models.Placar> Placar { get; set; }
    }
}
