using Amazon.Core.Modelos;
using Amazon.Infraestructura.Data;
using Amazon.Infraestructura.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Amazon.Infraestructura.Repositorio
{
    public class CarritoRepositorio : ICarritoRepositorio<Producto>
    {
        private readonly ApplicationDbContext _db;

        public CarritoRepositorio(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Producto>> ObtenerTodos()
        {
            return await _db.Productos.ToListAsync();
        }

        public async Task Agregar(Producto producto)
        {
            await _db.Productos.AddAsync(producto);
        }

        public void Remover(Producto producto)
        {
            _db.Productos.Remove(producto);
        }

        public async Task Guardar()
        {
            await _db.SaveChangesAsync();
        }

    }
}
