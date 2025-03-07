﻿using EyePocket.Data;
using EyePocket.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EyePocket.Service;

public class CXPServices(IDbContextFactory<ApplicationDbContext> DbFactory)
{

    public async Task<bool> Existe(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.CXP.AnyAsync(p => p.CuentaId == id);
    }
    private async Task<bool> Insertar(CXP cxp)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.CXP.Add(cxp);
        return await contexto.SaveChangesAsync() > 0;
    }
    private async Task<bool> Modificar(CXP cxp)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        var local = _context.CXP.Local
            .FirstOrDefault(p => p.CuentaId == cxp.CuentaId);
        _context.Entry(cxp).State = EntityState.Modified;
        return await _context.SaveChangesAsync() > 0;
    }
    public async Task<bool> Guardar(CXP cxp)
    {
        if (!await Existe(cxp.CuentaId))
            return await Insertar(cxp);
        else
            return await Modificar(cxp);
    }
    public async Task<bool> Eliminar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var cxp = await contexto.CXP
            .Where(p => p.CuentaId == id).ExecuteDeleteAsync();
        return cxp > 0;
    }
    public async Task<CXP?> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.CXP.AsNoTracking().
            FirstOrDefaultAsync(p => p.CuentaId == id);
    }
    public async Task<List<CXP>> Listar(Expression<Func<CXP, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.CXP.AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }

}
