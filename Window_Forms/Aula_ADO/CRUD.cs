using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;

namespace Aula_ADO
{
    public class CRUD
    {
        private string conexaoSQL = "Host=localhost;Database=Aula1;Username=postgres;Password=#Vasco2024";

        public void InserirUsuario(int id, string nome, string email)
        {
            string query = "INSERT INTO usuario (id, nome, email) VALUES (@id, @nome, @email)";
            using (NpgsqlConnection conexao = new NpgsqlConnection(conexaoSQL))
            {
                conexao.Open();
                using (NpgsqlCommand comando = new NpgsqlCommand(query, conexao))
                {
                    comando.Parameters.AddWithValue("@id", id);
                    comando.Parameters.AddWithValue("@nome", nome);
                    comando.Parameters.AddWithValue("@email", email);
                    comando.ExecuteNonQuery();
                }
            }
        }

        public List<string> ListarClientes()
        {
            List<string> lista = new List<string>();
            string query = "SELECT * FROM usuario";

            using (NpgsqlConnection conexao = new NpgsqlConnection(conexaoSQL))
            {
                conexao.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conexao))
                {
                    using (NpgsqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            string linha = $"ID: {dr["id"]} Nome: {dr["nome"]} Email: {dr["email"]}";
                            lista.Add(linha);
                        }
                    }
                }
            }
            return lista; // Retornar a lista preenchida
        }

        public void AtualizarUsuario(int id, string novoNome)
        {
            string query = "UPDATE usuario SET nome = @nome WHERE id = @id";
            using (NpgsqlConnection conexao = new NpgsqlConnection(conexaoSQL))
            {
                conexao.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conexao))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@nome", novoNome);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeletarUsuario(int id)
        {
            string query = "DELETE FROM usuario WHERE id = @id";
            using (NpgsqlConnection conexao = new NpgsqlConnection(conexaoSQL))
            {
                conexao.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conexao))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}