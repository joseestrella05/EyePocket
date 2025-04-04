namespace EyePocket.Service;

using EyePocket.Models;
using EyePocket.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


public class CiudadesService(IDbContextFactory<ApplicationDbContext> DbFactory)
{
    public async Task<bool> Guardar(Ciudades ciudad)
    {
        if (!await Existe(ciudad.CiudadId))
        {
            return await Insertar(ciudad);
        }
        else
        {
            return await Modificar(ciudad);
        }
    }

    public async Task<bool> Existe(int ciudadId)
    {
        await using var contexto = DbFactory.CreateDbContext();
        return await contexto.Ciudades.AnyAsync(c => c.CiudadId == ciudadId);
    }

    private async Task<bool> Insertar(Ciudades ciudad)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Ciudades.Add(ciudad);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Ciudades ciudad)
    {
        await using var Contexto = await DbFactory.CreateDbContextAsync();
        Contexto.Ciudades.Update(ciudad);
        return await Contexto.SaveChangesAsync() > 0;
    }

    public async Task<Ciudades?> Buscar(int CiudadId)
    {
        await using var Contexto = await DbFactory.CreateDbContextAsync();
        return await Contexto.Ciudades.Include(c => c.Cliente).FirstOrDefaultAsync(c => c.CiudadId == CiudadId);
    }

    public async Task<bool> Eliminar(int ciudadId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Ciudades.AsNoTracking().Where(c => c.CiudadId == ciudadId).ExecuteDeleteAsync() > 0;
    }

    public async Task<List<Ciudades>> Listar(Expression<Func<Ciudades, bool>> Criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Ciudades.Where(Criterio).AsNoTracking().ToListAsync();
    }

    public async Task<bool> ExisteNombre(int ciudad, string nombre)
    {
        await using var Contexto = await DbFactory.CreateDbContextAsync();
        return await Contexto.Ciudades.AnyAsync(c =>
            c.CiudadId != ciudad && c.CiudadNombre.ToLower().Equals(nombre.ToLower()));
    }
}