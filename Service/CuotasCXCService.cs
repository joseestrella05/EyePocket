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
	public async Task<List<CuotasCXC>> Buscar(int cxcId)
	{
		await using var contexto = await DbFactory.CreateDbContextAsync();
		return await contexto.CuotasCXC
			.AsNoTracking()
			.Where(c => c.CXCId == cxcId)
			.ToListAsync();
	}

	public async Task<List<CuotasCXC>> Listar(Expression<Func<CuotasCXC, bool>> criterio)
	{
		await using var contexto = await DbFactory.CreateDbContextAsync();
		return await contexto.CuotasCXC
			.Where(criterio)
			.ToListAsync();
	}

	public async Task<List<CuotasCXC>> CalcularCuotas(CuentasXCobrar cxc)
	{
		var listaCuotas = new List<CuotasCXC>();

		// Cálculo de interés total fijo y total a pagar
		double interesTotal = Math.Round((cxc.Interes / 100) * cxc.Capital, 2);
		double totalAPagar = Math.Round(cxc.Capital + interesTotal, 2);
		double cuotaSemanal = Math.Round(totalAPagar / cxc.Periodos, 2);
		double interesSemanal = Math.Round(interesTotal / cxc.Periodos, 2);

		double saldo = totalAPagar;

		for (int semana = 1; semana <= cxc.Periodos; semana++)
		{
			double pagoCapital = Math.Round(cuotaSemanal - interesSemanal, 2);
			double saldoFinal = Math.Round(saldo - cuotaSemanal, 2);

			// Última cuota ajustada para cuadrar todo
			if (semana == cxc.Periodos)
			{
				pagoCapital = saldo - interesSemanal;
				cuotaSemanal = pagoCapital + interesSemanal;
				saldoFinal = 0;
			}

			var cuota = new CuotasCXC
			{
				CXCId = cxc.CXCId,
				NumeroCuota = semana,
				Interes = interesSemanal,
				PagoCapital = pagoCapital,
				Mora = 0,
				SaldoFinal = saldoFinal,
				FechaVencimiento = DateTime.Now.AddDays(7 * semana),
				EstadoId = 1 // Pendiente
			};

			listaCuotas.Add(cuota);
			saldo = saldoFinal;
		}

		return listaCuotas;
	}




}