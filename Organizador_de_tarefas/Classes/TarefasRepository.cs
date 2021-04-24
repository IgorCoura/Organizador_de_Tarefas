using Organizador_de_tarefas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizador_de_tarefas.Classes
{
    public class TarefasRepository:IRepository<Tarefas>
    {
        private List<Tarefas> listaTarefas = new List<Tarefas>();
        public void Atualiza(int id, Tarefas obj)
        {
            Exclui(id);
            Insere(obj);
        }

        public void Exclui(int id)
        {
            listaTarefas.RemoveAll(x => x.Id == id);
        }


        public void Insere(Tarefas obj)
        {
            listaTarefas.Add(obj);
        }

        public List<Tarefas> Lista()
        {
            return listaTarefas;
        }
        public List<string[]> ListaArray()
        {
            listaTarefas.Sort(Tarefas.CompareByTime);
            List<string[]> lista = new List<string[]>();
            foreach(Tarefas t in listaTarefas)
            {
                t.AtualizarTempoRestante();
                lista.Add(new string[] {t.Id.ToString(), t.Status.ToString(), t.Descricao, t.Expiracao.ToString(), (t.DuracaoTarefa-t.ProgressoTarefa).ToString(), t.ProgressoTarefa.ToString()});
            }
            return lista;
        }

        public int ProximoId()
        {
            return listaTarefas.Count;
        }

        public Tarefas getId(int id)
        {
            return listaTarefas.Find(x => x.Id == id);
        }

    }
}
