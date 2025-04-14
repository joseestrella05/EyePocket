using EyePocket.Data;
using EyePocket.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace EyePocket.Service;

public class OrdenVentaService(IDbContextFactory<ApplicationDbContext> DbFactory)
{
    public async Task<bool> Guardar(OrdenVenta ordenVenta)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        if (!await Existe(ordenVenta.OrdenVentaId))
        {
            return await Insertar(ordenVenta);
        }
        else
        {
            return await Modificar(ordenVenta);
        }
    }
    private async Task<bool> Existe(int ordenVentaId)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.OrdenVenta
            .AnyAsync(c => c.OrdenVentaId == ordenVentaId);
    }
    private async Task<bool> Insertar(OrdenVenta ordenVenta)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        _contexto.OrdenVenta.Add(ordenVenta);
        return await _contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(OrdenVenta ordenVenta)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        _contexto.Update(ordenVenta);
        return await _contexto.SaveChangesAsync() > 0;

    }

    public async Task<bool> Eliminar(OrdenVenta ordenVenta)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.OrdenVenta
            .AsNoTracking()
            .Where(o => o.OrdenVentaId == ordenVenta.OrdenVentaId)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<bool> ExisteAgregados(int ordenVentaId, string Descripcion)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.OrdenVenta
            .AnyAsync(o => o.OrdenVentaId != ordenVentaId);
    }

    public async Task<OrdenVenta?> Buscar(int ordenVentaId)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.OrdenVenta
            .AsNoTracking()
            .FirstOrDefaultAsync(o => o.OrdenVentaId == ordenVentaId);
    }
	public async Task<List<OrdenVenta>> BuscarPorCliente(int clienteId)
	{
		await using var _contexto = await DbFactory.CreateDbContextAsync();

		return await _contexto.OrdenVenta
			.AsNoTracking()
			.Where(o => o.ClienteId == clienteId)
			.ToListAsync();
	}

	public async Task<List<OrdenVenta>> Listar(Expression<Func<OrdenVenta, bool>> criterio)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.OrdenVenta
            .Include(x => x.Clientes)
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
}