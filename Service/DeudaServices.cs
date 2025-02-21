using Microsoft.EntityFrameworkCore;
using EyePocket.Models;
using System.Linq.Expressions;
using EyePocket.Data;

namespace EyePocket.Service;

public class DeudaService(IDbContextFactory<ApplicationDbContext> DbFactory)
{
    public async Task<bool> Existe(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Deudas.AnyAsync(c => c.DeudasId == id);
    }
    private async Task<bool> Insertar(Deudas deuda)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Deudas.Add(deuda);
        return await contexto.SaveChangesAsync() > 0;
    }
    private async Task<bool> Modificar(Deudas deuda)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        var local = _context.Deudas.Local
            .FirstOrDefault(c => c.DeudasId == deuda.DeudasId);
        _context.Entry(deuda).State = EntityState.Modified;
        return await _context.SaveChangesAsync() > 0;
    }
    public async Task<bool> Guardar(Deudas deuda)
    {
        if (!await Existe(deuda.DeudasId))
            return await Insertar(deuda);
        else
            return await Modificar(deuda);
    }
    public async Task<bool> Eliminar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var Clientes = await contexto.Deudas
            .Where(c => c.DeudasId == id).ExecuteDeleteAsync();
        return Clientes > 0;
    }
    public async Task<Deudas?> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Deudas
            .Include(c => c.OrdenVenta)
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.DeudasId == id);
    }

    public async Task<List<Deudas>> Listar(Expression<Func<Deudas, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Deudas
        .Include(c => c.OrdenVenta)
          .ThenInclude (c => c.Clientes)
        .Where(criterio)
        .ToListAsync();
    }
}