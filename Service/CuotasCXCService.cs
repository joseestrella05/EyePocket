using EyePocket.Data;
using EyePocket.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using CuentasXCobrar = EyePocket.Models.CuentasXCobrar;

namespace EyePocket.Service;

public class CuotasCXCService(IDbContextFactory<ApplicationDbContext> DbFactory)
{
	public async Task<List<int>> Existe(List<int> idsCuotas)
	{
		await using var contexto = await DbFactory.CreateDbContextAsync();
		return await contexto.CuotasCXC
			.Where(c => idsCuotas.Contains(c.CuotaCXCID))
			.Select(c => c.CuotaCXCID)
			.ToListAsync();
	}

	private async Task<bool> Insertar(List<CuotasCXC> cuotas)
	{
		try
		{
			await using var contexto = await DbFactory.CreateDbContextAsync();
			await contexto.CuotasCXC
					.AddRangeAsync(cuotas);
			return await contexto.SaveChangesAsync() > 0;
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Error al insertar cuotas: {ex.Message}");
			return false;
		}
	}

	private async Task<bool> Modificar(List<CuotasCXC> cuotas)
	{
		try
		{
			await using var _context = await DbFactory.CreateDbContextAsync();

			foreach (var cuota in cuotas)
			{
				var local = _context.CuotasCXC
					.Local
					.FirstOrDefault(c => c.CuotaCXCID == cuota.CuotaCXCID);

				if (local != null)
					_context
						.Entry(local)
						.CurrentValues
						.SetValues(cuota);
				else
					_context
						.Entry(cuota)
						.State = EntityState.Modified;
			}
			return await _context.SaveChangesAsync() > 0;
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Error al modificar cuotas: {ex.Message}");
			return false;
		}
	}
	public async Task<bool> Guardar(List<CuotasCXC> cuotas)
	{
		if (cuotas == null || !cuotas.Any())
			return false;

		var idsCuotas = cuotas.Select(c => c.CuotaCXCID).ToList(); // Extrae los IDs de la lista de cuotas
		var existentes = await Existe(idsCuotas); // Obtiene los IDs que ya están en la BD

		var nuevas = cuotas.Where(c => !existentes.Contains(c.CuotaCXCID)).ToList(); // Cuotas nuevas
		var actualizar = cuotas.Where(c => existentes.Contains(c.CuotaCXCID)).ToList(); // Cuotas que existen y se deben actualizar

		if (nuevas.Any()) await Insertar(nuevas); // Insertamos las nuevas cuotas
		if (actualizar.Any()) await Modificar(actualizar); // Modificamos las existentes

		return true;
	}

	public async Task<bool> Eliminar(int id)
	{
		await using var contexto = await DbFactory.CreateDbContextAsync();
		var Cuota = await contexto.CuotasCXC
			.Where(c => c.CXCId == id)
			.ExecuteDeleteAsync();
		return Cuota > 0;
	}
	public async Task<CuotasCXC?> Buscar(int id)
	{
		await using var contexto = await DbFactory.CreateDbContextAsync();
		return await contexto.CuotasCXC
			.AsNoTracking()
			.FirstOrDefaultAsync(c => c.CuotaCXCID == id);
	}

	public async Task<List<CuotasCXC>> Listar(Expression<Func<CuotasCXC, bool>> criterio)
	{
		await using var contexto = await DbFactory.CreateDbContextAsync();
		return await contexto.CuotasCXC
			.Where(criterio)
			.ToListAsync();
	}

	public Task<List<CuotasCXC>> CalcularCuotas(CuentasXCobrar cuenta)
	{
		List<CuotasCXC> listaCuotas = new List<CuotasCXC>();
		double saldo = cuenta.Capital;
		double tasaMensual = cuenta.Interes / 100 / 12;
		double cuota = cuenta.Capital * (tasaMensual / (1 - Math.Pow(1 + tasaMensual, - cuenta.Periodos)));

		for (int mes = 1; mes <= cuenta.Periodos; mes++)
		{
			var cuotaAux = new CuotasCXC
			{
				CXCId = cuenta.CXCId,
				Interes = saldo * tasaMensual,
				PagoCapital = cuota - (saldo * tasaMensual),
				SaldoFinal = saldo - (cuota - (saldo * tasaMensual)),
				FechaVencimiento = DateTime.Now.AddMonths(mes),
				NumeroCuota = mes,
				EstadoId = 1
			};
			saldo = cuotaAux.SaldoFinal;
			listaCuotas.Add(cuotaAux);
		}

		return Task.FromResult(listaCuotas);
	}
}