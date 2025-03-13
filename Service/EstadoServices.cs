using EyePocket.Data;
using EyePocket.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EyePocket.Service;

public class EstadoServices(IDbContextFactory<ApplicationDbContext> DbFactory)
{
    public async Task<List<Estados>> Listar(Expression<Func<Estados, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Estados.AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
}
