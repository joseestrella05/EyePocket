using EyePocket.Data;
using EyePocket.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EyePocket.Service
{
    public class OrdenVentaService(IDbContextFactory<ApplicationDbContext> DbFactory)
    {
        public async Task<List<OrdenVenta>> Listar(Expression<Func<OrdenVenta, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.OrdenVenta
            .Include(c => c.Clientes)
            .Where(criterio)
            .ToListAsync();
        }
    }
}
