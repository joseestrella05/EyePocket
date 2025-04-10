using EyePocket.Data;
using EyePocket.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EyePocket.Service;

public class CierreCajaService(IDbContextFactory<ApplicationDbContext> DbFactory)
{
    public async Task<bool> Guardar(CierreCaja cierreCaja)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        if (!await Existe(cierreCaja.CierreId))
        {
            return await Insertar(cierreCaja);
        }
        else
        {
            return await Modificar(cierreCaja);
        }
    }
    private async Task<bool> Existe(int CierreCajaId)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.CierreCaja
            .AnyAsync(c => c.CierreId == CierreCajaId);
    }
    private async Task<bool> Insertar(CierreCaja cierreCaja)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        _contexto.CierreCaja.Add(cierreCaja);
        return await _contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(CierreCaja cierreCaja)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        _contexto.Update(cierreCaja);
        return await _contexto.SaveChangesAsync() > 0;

    }

    public async Task<bool> Eliminar(CierreCaja cierreCaja)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.CierreCaja
            .AsNoTracking()
            .Where(c => c.CierreId == cierreCaja.CierreId)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<CierreCaja?> Buscar(int cierreCajaId)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.CierreCaja
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.CierreId == cierreCajaId);
    }
    public async Task<List<CierreCaja>> Listar(Expression<Func<CierreCaja, bool>> criterio)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.CierreCaja
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
    public async Task<bool> ExisteCierreDeHoy()
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var hoy = DateTime.Today;
        return await contexto.CierreCaja.AnyAsync(c => c.Fecha.Date == hoy);
    }

}
