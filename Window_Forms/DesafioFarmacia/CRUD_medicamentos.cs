using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Npgsql;

namespace DesafioFarmacia
{
    public class CRUD_medicamentos 
    {
        private string conexaoSQL = "Host=localhost;Database=DesafioFarmacia;Username=postgres;Password=#Vasco2024";
        public void Inserir_Medicamento(string nome, string descricao,string tipo,double preco, estoque_atual, DateTime data_validade)
        {
            using (var con = new Conexao())
            {
                con.Database.EnsureCreated();
                con.Medicamentos.Add(new Medicamentos { Nome = nome, Descricao = descricao, Tipo = tipo, Preco = preco, Estoque_atual = estoque_atual, Data_validade = data_validade });
                con.SaveChanges();
            }
            
        }
        public void Listar_Medicamentos()
        {
            var medicamentos = con.Medicamentos.ToList();
            foreach (var medicamento in medicamentos)
            {
                Console.WriteLine(medicamento);
            }
        }
        public void Deletar_Medicamento(int id)
        {
            using (var con = new Conexao())
            {
                var medicamento = con.Medicamentos.Find(id);
                if (medicamento != null)
                {
                    con.Medicamentos.Remove(medicamento);
                    con.SaveChanges();
                    Console.WriteLine("Medicamento deletado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Medicamento nao encontrado!");
                }
            }
        }
        public void Atualizar_Medicamento(int id, string nome, string descricao, string tipo, double preco, int estoque_atual, DateTime data_validade)
        {
            using (var con = new Conexao())
            {
                var medicamento = con.Medicamentos.Find(id);
                if (medicamento != null)
                {
                    medicamento.Nome = nome;
                    medicamento.Descricao = descricao;
                    medicamento.Tipo = tipo;
                    medicamento.Preco = preco;
                    medicamento.Estoque_atual = estoque_atual;
                    medicamento.Data_validade = data_validade;
                    con.SaveChanges();
                    Console.WriteLine("Medicamento atualizado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Medicamento nao encontrado!");
                }
            }
        }        
    }
}