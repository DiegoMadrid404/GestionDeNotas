namespace RegistroNotas.Datos
{
    using Microsoft.EntityFrameworkCore;
    public partial class RegistronotasContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.\\sqlexpress;Initial Catalog=Notas;User ID=DiegoMadrid;Password=12345");
            }
        }
    }
}