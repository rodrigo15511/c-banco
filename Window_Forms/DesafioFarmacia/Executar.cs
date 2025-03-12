using System;
using Microsoft.EntityFrameworkCore;

namespace DesafioFarmacia
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new DbContextOptionsBuilder<Conexao>()
                .UseNpgsql("Host=localhost;Database=DesafioFarmacia;Username=postgres;Password=#Vasco2024")
                .Options;

            using (var contexto = new Conexao(options))
            {
                contexto.Database.EnsureCreated();
                Console.WriteLine("Conexão OK: " + contexto.Usuarios.Count());
            }

           
        }
    }
}