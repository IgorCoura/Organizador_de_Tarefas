using Organizador_de_tarefas.Classes;
using System;
using System.Collections.Generic;

namespace Organizador_de_tarefas
{
    class Program
    {
        private readonly static TarefasRepository _repository = new TarefasRepository();
        static void Main(string[] args)
        {
            string opcaoUsuario = "1";
            while (opcaoUsuario != "0")
            {
                Table table = new Table(1000, "ID","Status", "Descricao", "Expiration", "Ha Fazer", "Ja feito");
                table.printTable(_repository.ListaArray());
                opcaoUsuario = getOpcoes();
                switch (opcaoUsuario)
                {
                    case "1":
                        AddTarefa();
                        break;
                    case "2":
                        AddProgresso();
                        break;
                    case "3":
                        editarTarefa();
                        break;
                    case "4":
                        finalizarTarefa();
                        break;
                }
            }
            
        }

        static string getOpcoes()
        {
            Console.WriteLine("Opcoes:");
            Console.WriteLine("1-Add Tarefa.");
            Console.WriteLine("2-Add Progresso.");
            Console.WriteLine("3-Editar Tarefa.");
            Console.WriteLine("4-Finalizar Tarefa.");
            Console.WriteLine("0-Sair");
            Console.WriteLine();
            return Console.ReadLine();
        }

        static void AddTarefa()
        {
            Console.WriteLine("\nNova Tarefa.\n");
            Console.WriteLine("Descrição: ");
            var descricao = Console.ReadLine();
            Console.WriteLine("Expiração: ("+DateTime.MaxValue+")");
            var expiracao = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Duração: ("+TimeSpan.Zero+")");
            var duracao = TimeSpan.Parse(Console.ReadLine());
            Tarefas tarefa = new Tarefas(_repository.ProximoId(),descricao, expiracao, duracao);
            _repository.Insere(tarefa);
            Console.Clear();
        }

        static void AddProgresso()
        {
            Console.WriteLine("\nId da tarefa: ");
            var id = int.Parse(Console.ReadLine());
            var tarefa = _repository.getId(id);
            if(tarefa != null)
            {
                Console.WriteLine("Progresso: (" + TimeSpan.Zero + ")");
                var progresso  = TimeSpan.Parse(Console.ReadLine());
                tarefa.ProgressoTarefa += progresso;
                _repository.Atualiza(id, tarefa);
                Console.Clear();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Id invalido.\n");
            }
        }

        static void editarTarefa()
        {
            Console.WriteLine("\nEditar Tarefa.\n");
            Console.WriteLine("Id da tarefa: ");
            var id = int.Parse(Console.ReadLine());
            var tarefa = _repository.getId(id);
            if(tarefa != null)
            {
                Console.WriteLine("Descrição: ");
                var descricao = Console.ReadLine();
                Console.WriteLine("Expiração: (" + DateTime.MaxValue + ")");
                var expiracao = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Duração: (" + TimeSpan.Zero + ")");
                var duracao = TimeSpan.Parse(Console.ReadLine());
                tarefa = new Tarefas(id, descricao, expiracao, duracao);
                Console.WriteLine("Progresso: (" + TimeSpan.Zero + ")");
                var progresso = TimeSpan.Parse(Console.ReadLine());
                tarefa.ProgressoTarefa += progresso;
                _repository.Atualiza(id, tarefa);
                Console.Clear();
            }
            else
            {
                Console.Clear();
                Console.Write("Id invalido\n");
            }
            
        }

        static void finalizarTarefa()
        {
            Console.WriteLine("\nFinalizar Tarefa\n");
            Console.WriteLine("Id da tareafa: ");
            var id = int.Parse(Console.ReadLine());
            _repository.Exclui(id);
            Console.Clear();
        }
    }
}
