using EyePocket.Data;
using EyePocket.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EyePocket.Service
{
    public class PagoService(IDbContextFactory<ApplicationDbContext> DbFactory)
    {
        public async Task<bool> Existe(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.pago.AnyAsync(p => p.PagoId == id);
        }
        private async Task<bool> Insertar(Pago pago)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.pago.Add(pago);
            return await contexto.SaveChangesAsync() > 0;
        }
        private async Task<bool> Modificar(Pago pago)
        {
            await using var _context = await DbFactory.CreateDbContextAsync();
            var local = _context.pago.Local
                .FirstOrDefault(p => p.PagoId == pago.PagoId);
            _context.Entry(pago).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> Guardar(Pago pago)
        {
            if (!await Existe(pago.PagoId))
                return await Insertar(pago);
            else
                return await Modificar(pago);
        }
        public async Task<bool> Eliminar(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            var pago = await contexto.pago
                .Where(p => p.PagoId == id).ExecuteDeleteAsync();
            return pago > 0;
        }
        public async Task<Pago?> Buscar(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.pago.AsNoTracking().
                FirstOrDefaultAsync(p => p.PagoId == id);
        }
        public async Task<List<Pago>> Listar(Expression<Func<Pago, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.pago.AsNoTracking()
                .Include(p => p.MetodoPago)
                .Where(criterio)
                .ToListAsync();
        }
    }
}
