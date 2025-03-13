using EyePocket.Data;
using EyePocket.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EyePocket.Service
{
    public class OrdenCompraDetalleService(IDbContextFactory<ApplicationDbContext> DbFactory)
    {
 
        public async Task<List<Productos>> Listar(Expression<Func<Productos, bool>> criterio)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Productos.Where(criterio).ToListAsync();
        }
        public async Task<bool> Agregar(int productoId, int cantidad)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            if (cantidad <= 0)
            {
                throw new ArgumentException("Error, la cantidad debe ser mayor que cero.");
            }

            var producto = await contexto.Productos.FindAsync(productoId);

            if (producto != null)
            {
                contexto.Productos.Update(producto);
                await contexto.SaveChangesAsync();
                return true;
            }
            return false;
        }

    }
}
