using ApiOAuthEmpleados.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiOAuthEmpleados.Context
{
    public class HospitalContext:DbContext
    {
        public HospitalContext(DbContextOptions<HospitalContext>options)
            : base(options) { }
        public DbSet<Empleado>Empleados { get; set; }
    }
}
