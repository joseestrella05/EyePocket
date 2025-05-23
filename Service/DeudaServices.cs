﻿using Microsoft.EntityFrameworkCore;
using EyePocket.Models;
using System.Linq.Expressions;
using EyePocket.Data;

namespace EyePocket.Service;

public class CuentasXCobrarService(IDbContextFactory<ApplicationDbContext> DbFactory)
{
    public async Task<bool> Existe(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.CuentasXCobrar.AnyAsync(c => c.CXCId == id);
    }
	private async Task<bool> Insertar(CuentasXCobrar deuda)
	{
		await using var contexto = await DbFactory.CreateDbContextAsync();

		// Cargar la entidad OrdenVenta antes de insertarla en CuentasXCobrar
		deuda.OrdenVenta = await contexto.OrdenVenta
			.FirstOrDefaultAsync(o => o.OrdenVentaId == deuda.OrdenVentaId);

		// Verificar si OrdenVenta se ha cargado correctamente
		if (deuda.OrdenVenta == null)
		{
			// Lanzar excepción si no se encuentra la OrdenVenta
			throw new Exception("⚠ ERROR: No se encontró la OrdenVenta en la base de datos.");
		}


		// Agregar la deuda al contexto y guardar los cambios
		contexto.CuentasXCobrar.Add(deuda);
		return await contexto.SaveChangesAsync() > 0;
	}

	private async Task<bool> Modificar(CuentasXCobrar deuda)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        var local = _context.CuentasXCobrar.Local
            .FirstOrDefault(c => c.CXCId == deuda.CXCId);
        _context.Entry(deuda).State = EntityState.Modified;
        return await _context.SaveChangesAsync() > 0;
    }
    public async Task<bool> Guardar(CuentasXCobrar deuda)
    {
        if (!await Existe(deuda.CXCId))
            return await Insertar(deuda);
        else
            return await Modificar(deuda);
    }
    public async Task<bool> Eliminar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var Clientes = await contexto.CuentasXCobrar
            .Where(c => c.CXCId == id).ExecuteDeleteAsync();
        return Clientes > 0;
    }
    public async Task<CuentasXCobrar?> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.CuentasXCobrar
            .Include(c => c.OrdenVenta)
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.CXCId == id);
    }

    public async Task<List<CuentasXCobrar>> Listar(Expression<Func<CuentasXCobrar, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.CuentasXCobrar
        .Include(x => x.Estados)
        .Include(x => x.ListaCuotasCXC)
        .Include(c => c.OrdenVenta)
          .ThenInclude (c => c.Clientes)
        .Where(criterio)
        .ToListAsync();
    }
}