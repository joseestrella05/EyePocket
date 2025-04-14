using EyePocket.Data;
using EyePocket.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EyePocket.Service
{
    public class MetodosPagoService(IDbContextFactory<ApplicationDbContext> DbFactory)
    {

        public async Task<List<MetodosPago>> Listar(Expression<Func<MetodosPago, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.MetodosPago.AsNoTracking()
                .Where(criterio)
            .ToListAsync();
        }


        public async Task<MetodosPago?> Buscar(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.MetodosPago.AsNoTracking().
                FirstOrDefaultAsync(p => p.MetodoPagoId == id);
        }
    }
}
