using EyePocket.Data;
using EyePocket.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EyePocket.Service
{
    public class EstadoCXPService(IDbContextFactory<ApplicationDbContext> DbFactory)
    {

        public async Task<List<EstadoCXP>> Listar(Expression<Func<EstadoCXP, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.EstadoCXP.AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }


        public async Task<EstadoCXP?> Buscar(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.EstadoCXP.AsNoTracking().
                FirstOrDefaultAsync(p => p.EstadoCXPId == id);
        }



    }
}
