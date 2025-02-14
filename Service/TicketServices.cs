using System.Linq.Expressions;
using EyePocket.Data;
using EyePocket.Models;
using Microsoft.EntityFrameworkCore;

namespace EyePocket.Service;

public class TicketServices (IDbContextFactory<ApplicationDbContext> DbFactory)
{

    public async Task<bool> Guardar(Tickets ticket)
    {
        if (!await Existe(ticket.TicketId))
        {
           return await Insertar(ticket);
        }
        else
        {
            return await Modificar(ticket);
        }
    }

    public async Task<bool> Existe(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Tickets.AnyAsync(t => t.TicketId == id);
    }

    private async Task<bool> Insertar(Tickets ticket)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Add(ticket);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Tickets ticket)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Update(ticket);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Eliminar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Tickets.Where(t => t.TicketId == id).ExecuteDeleteAsync()>0;
    }

    public async Task<Tickets?> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Tickets.AsNoTracking().FirstOrDefaultAsync(t => t.TicketId == id);
    }

    public async Task<List<Tickets>> Listar(Expression<Func<Tickets, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Tickets.AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
    
    
}