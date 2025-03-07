using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Exercicio_Entity
{
    public class CRUD
    {
        private readonly MeuContexto _contexto;

        public CRUD(MeuContexto contexto)
        {
            _contexto = contexto;
        }

        // CRUD para Maquina
        public void InserirMaquina(Maquina maquina)
        {
            try
            {
                _contexto.Maquinas.Add(maquina);
                _contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir máquina: " + ex.Message);
            }
        }

        public List<Maquina> ListarMaquinas()
        {
            try
            {
                return _contexto.Maquinas
                    .Include(m => m.Usuario) // Inclui o usuário relacionado
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar máquinas: " + ex.Message);
            }
        }

        public Maquina BuscarMaquinaPorId(int id)
        {
            try
            {
                return _contexto.Maquinas
                    .Include(m => m.Usuario)
                    .FirstOrDefault(m => m.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar máquina: " + ex.Message);
            }
        }

        public void AtualizarMaquina(Maquina maquinaAtualizada)
        {
            try
            {
                var maquinaExistente = _contexto.Maquinas.Find(maquinaAtualizada.Id);
                if (maquinaExistente == null)
                    throw new Exception("Máquina não encontrada");

                maquinaExistente.Tipo = maquinaAtualizada.Tipo;
                maquinaExistente.Velocidade = maquinaAtualizada.Velocidade;
                maquinaExistente.HardDisk = maquinaAtualizada.HardDisk;
                maquinaExistente.Placa_Rede = maquinaAtualizada.Placa_Rede;
                maquinaExistente.Memoria_Ram = maquinaAtualizada.Memoria_Ram;
                maquinaExistente.Fk_Usuario = maquinaAtualizada.Fk_Usuario;

                _contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar máquina: " + ex.Message);
            }
        }

        public void DeletarMaquina(int id)
        {
            try
            {
                var maquina = _contexto.Maquinas.Find(id);
                if (maquina == null)
                    throw new Exception("Máquina não encontrada");

                _contexto.Maquinas.Remove(maquina);
                _contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao deletar máquina: " + ex.Message);
            }
        }
    }
}