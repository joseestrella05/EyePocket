using EyePocket.Data;
using EyePocket.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EyePocket.Service
{
    public class OrdenVentasDetalleService(IDbContextFactory<ApplicationDbContext> DbFactory)
    {
        public async Task<List<OrdenVentaDetalle>> Listar(Expression<Func<OrdenVentaDetalle, bool>> criterio)
        {
            await using var _contexto = await DbFactory.CreateDbContextAsync();

            return await _contexto.OrdenVentasDetalle
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}
