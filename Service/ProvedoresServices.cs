using EyePocket.Data;
using EyePocket.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EyePocket.Service;

public class ProvedoresServices(IDbContextFactory<ApplicationDbContext> DbFactory)
{
    public async Task<bool> Existe(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Provedores.AnyAsync(p => p.ProvedorId == id);
    }
    private async Task<bool> Insertar(Provedores provedor)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Provedores.Add(provedor);
        return await contexto.SaveChangesAsync() > 0;
    }
    private async Task<bool> Modificar(Provedores provedor)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        var local = _context.Provedores.Local
            .FirstOrDefault(p => p.ProvedorId == provedor.ProvedorId);
        _context.Entry(provedor).State = EntityState.Modified;
        return await _context.SaveChangesAsync() > 0;
    }
    public async Task<bool> Guardar(Provedores provedore)
    {
        if (!await Existe(provedore.ProvedorId))
            return await Insertar(provedore);
        else
            return await Modificar(provedore);
    }
    public async Task<bool> Eliminar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var Provedor = await contexto.Provedores
            .Where(p => p.ProvedorId == id).ExecuteDeleteAsync();
        return Provedor > 0;
    }
    public async Task<Provedores?> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Provedores.AsNoTracking().
            FirstOrDefaultAsync(p => p.ProvedorId == id);
    }
    public async Task<Provedores?> BuscarNombres(string nombre)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Provedores.AsNoTracking()
            .FirstOrDefaultAsync(p => p.Nombre == nombre);
    }
    public async Task<List<Provedores>> Listar(Expression<Func<Provedores, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Provedores.AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
}
