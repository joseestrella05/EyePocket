using EyePocket.Data;
using EyePocket.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EyePocket.Service
{
    public class EstadoOdService(IDbContextFactory<ApplicationDbContext> DbFactory)
    {
        public async Task<List<EstadoOrdenCompra>> Listar(Expression<Func<EstadoOrdenCompra, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.estadoOdCompra.AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }

    }
}
