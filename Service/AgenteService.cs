using System.Linq.Expressions;
using EyePocket.Data;
using EyePocket.Models;
using Microsoft.EntityFrameworkCore;

namespace EyePocket.Service;

public class AgenteServices(IDbContextFactory<ApplicationDbContext> DbFactory)
{
    public async Task<bool> Guardar(Agentes agente)
    {
        if (!await Existe(agente.AgenteId))
        {
            return await Insertar(agente);
        }
        else
        {
            return await Modificar(agente);
        }
    }

    public async Task<bool> Existe(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Agentes.AnyAsync(a => a.AgenteId == id);
    }

    private async Task<bool> Insertar(Agentes agente)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Add(agente);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Agentes agente)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Update(agente);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Eliminar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Agentes.Where(a => a.AgenteId == id).ExecuteDeleteAsync() > 0;
    }

    public async Task<Agentes?> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Agentes.AsNoTracking().FirstOrDefaultAsync(a => a.AgenteId == id);
    }

    public async Task<List<Agentes>> Listar(Expression<Func<Agentes, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Agentes.AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
    
}