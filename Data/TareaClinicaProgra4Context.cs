
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TareaClinicaProgra4.Models;

namespace TareaClinicaProgra4.Data
{
    public class TareaClinicaProgra4Context : DbContext
    {
        public TareaClinicaProgra4Context (DbContextOptions<TareaClinicaProgra4Context> options)
            : base(options)
        {
        }

        public DbSet<TareaClinicaProgra4.Models.Virus> Virus { get; set; } = default!;
    }
}
