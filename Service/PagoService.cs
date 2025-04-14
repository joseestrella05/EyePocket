using EyePocket.Data;
using Microsoft.EntityFrameworkCore;
using EyePocket.Models;
using System.Linq.Expressions;

namespace EyePocket.Service
{
        public class PagoService(IDbContextFactory<ApplicationDbContext> DbFactory)
        {
            public async Task<bool> Existe(int id)
            {
                await using var contexto = await DbFactory.CreateDbContextAsync();
                return await contexto.pagocxp.AnyAsync(p => p.PagoId == id);
            }
            private async Task<bool> Insertar(PagoCXP pago)
            {
                await using var contexto = await DbFactory.CreateDbContextAsync();
                contexto.pagocxp.Add(pago);
                return await contexto.SaveChangesAsync() > 0;
            }
            private async Task<bool> Modificar(PagoCXP pago)
            {
                await using var _context = await DbFactory.CreateDbContextAsync();
                var local = _context.pagocxp.Local
                    .FirstOrDefault(p => p.PagoId == pago.PagoId);
                _context.Entry(pago).State = EntityState.Modified;
                return await _context.SaveChangesAsync() > 0;
            }
            public async Task<bool> Guardar(PagoCXP pago)
            {
                if (!await Existe(pago.PagoId))
                    return await Insertar(pago);
                else
                    return await Modificar(pago);
            }
            public async Task<bool> Eliminar(int id)
            {
                await using var contexto = await DbFactory.CreateDbContextAsync();
                var pago = await contexto.pagocxp
                    .Where(p => p.PagoId == id).ExecuteDeleteAsync();
                return pago > 0;
            }
            public async Task<PagoCXP?> Buscar(int id)
            {
                await using var contexto = await DbFactory.CreateDbContextAsync();
                return await contexto.pagocxp.AsNoTracking().
                    FirstOrDefaultAsync(p => p.PagoId == id);
            }
            public async Task<List<PagoCXP>> Listar(Expression<Func<PagoCXP, bool>> criterio)
            {
                await using var contexto = await DbFactory.CreateDbContextAsync();
                return await contexto.pagocxp.AsNoTracking()
                    .Include(p => p.MetodoPago)
                    .Where(criterio)
                    .ToListAsync();
            }
        }
    }

