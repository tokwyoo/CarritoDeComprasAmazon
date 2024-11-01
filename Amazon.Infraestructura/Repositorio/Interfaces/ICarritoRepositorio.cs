using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Infraestructura.Repositorio.Interfaces
{
    public interface ICarritoRepositorio<T> where T : class
    {
        Task<IEnumerable<T>> ObtenerTodos();
        Task Agregar(T entidad);
        void Remover(T entidad);
        Task Guardar();
    }
}
