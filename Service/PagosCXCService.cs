using Microsoft.EntityFrameworkCore;
using EyePocket.Models;
using System.Linq.Expressions;
using EyePocket.Data;

namespace EyePocket.Service;

public class PagosCXCService(IDbContextFactory<ApplicationDbContext> DbFactory)
{
	public async Task<bool> Existe(int id)
	{
		await using var contexto = await DbFactory.CreateDbContextAsync();
		return await contexto.PagosCXC
			.AnyAsync(c => c.Id == id);
	}
	private async Task<bool> Insertar(PagosCXC pago)
	{
		await using var contexto = await DbFactory.CreateDbContextAsync();
		contexto.PagosCXC
			.Add(pago);
		return await contexto.SaveChangesAsync() > 0;
	}
	private async Task<bool> Modificar(PagosCXC pago)
	{
		await using var _context = await DbFactory.CreateDbContextAsync();
		var local = _context.PagosCXC
			.Local
			.FirstOrDefault(c => c.Id == pago.Id);

		_context.Entry(pago).State = EntityState.Modified;

		return await _context.SaveChangesAsync() > 0;
	}
	public async Task<bool> Guardar(PagosCXC pago)
	{
		if (!await Existe(pago.Id))
			return await Insertar(pago);
		else
			return await Modificar(pago);
	}
	public async Task<bool> Eliminar(int id)
	{
		await using var contexto = await DbFactory.CreateDbContextAsync();
		var Pago = await contexto.PagosCXC
			.Where(c => c.Id == id)
			.ExecuteDeleteAsync();
		return Pago > 0;
	}
	public async Task<PagosCXC?> Buscar(int id)
	{
		await using var contexto = await DbFactory.CreateDbContextAsync();
		return await contexto.PagosCXC
			.AsNoTracking()
			.FirstOrDefaultAsync(c => c.Id == id);
	}

	public async Task<List<PagosCXC>> Listar(Expression<Func<PagosCXC, bool>> criterio)
	{
		await using var contexto = await DbFactory.CreateDbContextAsync();
		return await contexto.PagosCXC
			.Include(c => c.Deuda)
			.Where(criterio)
			.ToListAsync();
	}
}