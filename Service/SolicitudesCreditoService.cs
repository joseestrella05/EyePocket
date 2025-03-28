using EyePocket.Data;
using EyePocket.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;
namespace EyePocket.Service;


public class SolicitudesCreditoService(IDbContextFactory<ApplicationDbContext> DbFactory)
{
    public async Task<bool> Guardar(SolicitudesCredito solicitud)
    {
        if (!await Existe(solicitud.SolicitudCreditoId))
        {
            return await Insertar(solicitud);
        }
        else
        {
            return await Modificar(solicitud);
        }
    }

    public async Task<bool> Existe(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.SolicitudesCredito.AnyAsync(a => a.SolicitudCreditoId == id);
    }

    private async Task<bool> Insertar(SolicitudesCredito solicitud)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.SolicitudesCredito.Add(solicitud);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(SolicitudesCredito solicitud)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Update(solicitud);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Eliminar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.SolicitudesCredito.Where(a => a.SolicitudCreditoId == id).ExecuteDeleteAsync() > 0;
    }

    public async Task<SolicitudesCredito?> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.SolicitudesCredito
            .Include(x => x.Cliente)
            .FirstOrDefaultAsync(a => a.SolicitudCreditoId == id);
    }

    public async Task<List<SolicitudesCredito>> Listar(Expression<Func<SolicitudesCredito, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.SolicitudesCredito
            .Include(x => x.Cliente)
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<List<CuotasCXC>> ObtenerCuotas(int id)
    {
        CuotasCXCService CxCS = new CuotasCXCService(DbFactory);
        List<CuotasCXC> Cuotas = [];
        await using var contexto = await DbFactory.CreateDbContextAsync();
        List<OrdenVenta> OrdenVentas = await contexto.OrdenVenta
                                                     .Where(C => C.ClienteId == id)
                                                     .ToListAsync();
      foreach (var orden in OrdenVentas)
        {
            if(await contexto.CuentasXCobrar.AnyAsync(C => C.OrdenVentaId == orden.OrdenVentaId))
            {
                var Cuenta = await contexto.CuentasXCobrar
                                           .Where(C => C.OrdenVentaId == orden.OrdenVentaId)
                                           .Include(C => C.ListaCuotasCXC) 
                                           .FirstOrDefaultAsync();
                var CUoTAS = await CxCS.Buscar(Cuenta.CXCId);

                Cuotas.AddRange(CUoTAS);
            }
        }

        return Cuotas;
    }

    public async Task<bool> ActulizarEstado(int id, int estadoId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var solicitud = await contexto.SolicitudesCredito.FirstOrDefaultAsync(a => a.SolicitudCreditoId == id);
        solicitud.EstadosId = estadoId;
        contexto.SolicitudesCredito.Update(solicitud);
        return await contexto.SaveChangesAsync() > 0;
    }
}
