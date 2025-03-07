using EyePocket.Data;
using EyePocket.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EyePocket.Service;

public class MetodoPagoService(IDbContextFactory<ApplicationDbContext> DbFactory)
{
    public async Task<List<MetodoPago>> Listar(Expression<Func<MetodoPago, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.MetodoPagos.AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }


    public async Task<MetodoPago?> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.MetodoPagos.AsNoTracking().
            FirstOrDefaultAsync(p => p.MetodoPagoId == id);
    }

}