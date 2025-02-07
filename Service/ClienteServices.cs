using Microsoft.EntityFrameworkCore;
using EyePocket.Models;
using System.Linq.Expressions;
using EyePocket.Data;

namespace EyePocket.Service;

public class ClienteServices(IDbContextFactory<ApplicationDbContext> DbFactory)
{
    public async Task<bool> Existe(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Clientes.AnyAsync(c => c.ClienteId == id);
    }
    private async Task<bool> Insertar(Clientes cliente)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Clientes.Add(cliente);
        return await contexto.SaveChangesAsync() > 0;
    }
    private async Task<bool> Modificar(Clientes cliente)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        var local = _context.Clientes.Local
            .FirstOrDefault(c => c.ClienteId == cliente.ClienteId);
        _context.Entry(cliente).State = EntityState.Modified;
        return await _context.SaveChangesAsync() > 0;
    }
    public async Task<bool> Guardar(Clientes cliente)
    {
        if (!await Existe(cliente.ClienteId))
            return await Insertar(cliente);
        else
            return await Modificar(cliente);
    }
    public async Task<bool> Eliminar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var Clientes = await contexto.Clientes
            .Where(c => c.ClienteId == id).ExecuteDeleteAsync();
        return Clientes > 0;
    }
    public async Task<Clientes?> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Clientes.AsNoTracking().
            FirstOrDefaultAsync(c => c.ClienteId == id);
    }
    public async Task<Clientes?> BuscarNombres(string nombre)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Clientes.AsNoTracking()
            .FirstOrDefaultAsync(c => c.Nombre == nombre);
    }
    public async Task<Clientes?> BuscarRNC(string cedula)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Clientes.AsNoTracking()
            .FirstOrDefaultAsync(c => c.Cedula == cedula);
    }
    public async Task<List<Clientes>> Listar(Expression<Func<Clientes, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Clientes.AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
}