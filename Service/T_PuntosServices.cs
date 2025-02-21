using System.Linq.Expressions;
using EyePocket.Data;
using EyePocket.Models;
using Microsoft.EntityFrameworkCore;

namespace EyePocket.Service;

public class T_PuntosServices (IDbContextFactory<ApplicationDbContext> DbFactory)
{
    public async Task<bool> Guardar(TarjetaPuntos tarjeta)
    {
        if (!await Existe(tarjeta.TarjetaId))
        {
            return await Insertar(tarjeta);
        }
        else
        {
            return await Modificar(tarjeta);
        }
    }

    public async Task<bool> Existe(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.TarjetaPuntos.AnyAsync(t => t.TarjetaId == id);
    }

    private async Task<bool> Insertar(TarjetaPuntos tarjeta)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Add(tarjeta);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(TarjetaPuntos tarjeta)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Update(tarjeta);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Eliminar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.TarjetaPuntos.Where(t => t.TarjetaId == id).ExecuteDeleteAsync()>0;
    }

    public async Task<TarjetaPuntos?> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.TarjetaPuntos.AsNoTracking().FirstOrDefaultAsync(t => t.TarjetaId == id);
    }

    public async Task<List<TarjetaPuntos>> Listar(Expression<Func<TarjetaPuntos, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.TarjetaPuntos.AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
}