using EyePocket.Data;
using EyePocket.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EyePocket.Service;

public class CompraServices(IDbContextFactory<ApplicationDbContext> DbFactory)
{
    public async Task<bool> Existe(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Compras.AnyAsync(p => p.CompraId == id);
    }
    private async Task<bool> Insertar(Compras compra)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Compras.Add(compra);
        return await contexto.SaveChangesAsync() > 0;
    }
    private async Task<bool> Modificar(Compras compra)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        var local = _context.Compras.Local
            .FirstOrDefault(p => p.ProvedorId == compra.CompraId);
        _context.Entry(compra).State = EntityState.Modified;
        return await _context.SaveChangesAsync() > 0;
    }
    public async Task<bool> Guardar(Compras compra)
    {
        if (!await Existe(compra.CompraId))
            return await Insertar(compra);
        else
            return await Modificar(compra);
    }
    public async Task<bool> Eliminar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        // Buscar la compra incluyendo los detalles
        var compra = await contexto.Compras
            .Include(c => c.ComprasDetalles)
            .FirstOrDefaultAsync(c => c.CompraId == id);

        if (compra == null)
            return false;

        // Eliminar detalles primero
        contexto.ComprasDetalles.RemoveRange(compra.ComprasDetalles);

        // Eliminar la compra
        contexto.Compras.Remove(compra);

        await contexto.SaveChangesAsync();
        return true;
    }


    public async Task<Compras?> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Compras.AsNoTracking()
            .Include(c => c.ComprasDetalles).
            FirstOrDefaultAsync(p => p.CompraId == id);
    }
    public async Task<List<Compras>> Listar(Expression<Func<Compras, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Compras
            .Include(p => p.Provedor)
            .Include(c => c.ComprasDetalles)
                 .ThenInclude(d => d.Productos)
            .Where(criterio)
            .ToListAsync();
    }
}