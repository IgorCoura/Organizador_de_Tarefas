using Organizador_de_tarefas.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizador_de_tarefas.Classes
{
    public class Tarefas: EntidadeBase
    {
        private Status status = Status.EmDia;
        private TimeSpan progressoTarefa = TimeSpan.Zero;
        private TimeSpan tempoRestante;

        public Tarefas(int id, string descricao, DateTime expiracao, TimeSpan duracaoTarefa)
        {
            this.Id = id;
            Descricao = descricao;
            Expiracao = expiracao;
            DuracaoTarefa = duracaoTarefa;
        }

        public Status Status { get => status;}
        public string Descricao { get; set; }
        public DateTime Expiracao { get; set; }
        public TimeSpan DuracaoTarefa { get; set; }
        public TimeSpan ProgressoTarefa { get => progressoTarefa; set => progressoTarefa = value; }

        public void AtualizarTempoRestante()
        {
            tempoRestante = Expiracao - DateTime.Now - DuracaoTarefa - ProgressoTarefa;
            AtualizarStatus();
        }

        private void AtualizarStatus()
        {
            var haFazer = DuracaoTarefa - progressoTarefa;
            var prazo = Expiracao - DateTime.Now;
            if (prazo < TimeSpan.Zero)
            {
                status = Status.Expirado;
            }
            else if (haFazer > prazo)
            {                
                status = Status.Atrasado;
            }            
            else
            {
                status = Status.EmDia;
            }
        }



        public static int CompareByTime(Tarefas tarefa1, Tarefas tarefa2)
        {
            tarefa1.AtualizarTempoRestante();
            tarefa2.AtualizarTempoRestante();
            return TimeSpan.Compare(tarefa1.tempoRestante, 
                                    tarefa2.tempoRestante);
        }


    }
}
