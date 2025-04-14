using Microsoft.EntityFrameworkCore;
using EyePocket.Models;
using System.Linq.Expressions;
using EyePocket.Data;

namespace EyePocket.Service;

public class DevolucionesService(IDbContextFactory<ApplicationDbContext> DbFactory)
{
    
public async Task<bool> Existe(int id)
{
    await using var contexto = await DbFactory.CreateDbContextAsync();
    return await contexto.Devoluciones.AnyAsync(d => d.DevolucionId == id);
}

private async Task<bool> Insertar(Devoluciones devolucion)
{
    await using var contexto = await DbFactory.CreateDbContextAsync();
    contexto.Devoluciones.Add(devolucion);
    return await contexto.SaveChangesAsync() > 0;
}

private async Task<bool> Modificar(Devoluciones devolucion)
{
    await using var contexto = await DbFactory.CreateDbContextAsync();
    // Si existe alguna instancia en el contexto, opcionalmente podrías removerla
    var local = contexto.Devoluciones.Local
        .FirstOrDefault(d => d.DevolucionId == devolucion.DevolucionId);
    if(local is not null)
        contexto.Entry(local).State = EntityState.Detached;

    contexto.Entry(devolucion).State = EntityState.Modified;
    return await contexto.SaveChangesAsync() > 0;
}

public async Task<bool> Guardar(Devoluciones devolucion)
{
    if (!await Existe(devolucion.DevolucionId))
        return await Insertar(devolucion);
    else
        return await Modificar(devolucion);
}

public async Task<bool> Eliminar(int id)
{
    await using var contexto = await DbFactory.CreateDbContextAsync();
    var registrosAfectados = await contexto.Devoluciones
        .Where(d => d.DevolucionId == id)
        .ExecuteDeleteAsync();
    return registrosAfectados > 0;
}

public async Task<Devoluciones?> Buscar(int id)
{
    await using var contexto = await DbFactory.CreateDbContextAsync();
    return await contexto.Devoluciones.AsNoTracking()
        .FirstOrDefaultAsync(d => d.DevolucionId == id);
}

// Ejemplo de método para buscar por Asunto, similar al BuscarNombres en el service de Clientes
public async Task<Devoluciones?> BuscarAsunto(string asunto)
{
    await using var contexto = await DbFactory.CreateDbContextAsync();
    return await contexto.Devoluciones.AsNoTracking()
        .FirstOrDefaultAsync(d => d.Asunto == asunto);
}

public async Task<List<Devoluciones>> Listar(Expression<Func<Devoluciones, bool>> criterio)
{
    await using var contexto = await DbFactory.CreateDbContextAsync();
    return await contexto.Devoluciones.AsNoTracking()
        .Where(criterio)
        .ToListAsync();
}
}