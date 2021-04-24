using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizador_de_tarefas.Interfaces
{
    public interface IRepository<T>
    {
        List<T> Lista();
        void Insere(T entidade);
        void Exclui(int id);
        void Atualiza(int id, T entidade);
        int ProximoId();
        public T getId(int id);
    }
}
