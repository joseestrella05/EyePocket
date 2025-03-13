using EyePocket.Data;
using EyePocket.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EyePocket.Service
{
    public class OrdenCompraService(IDbContextFactory<ApplicationDbContext> DbFactory)
    {
        public async Task<bool> Existe(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.ordenCompra.AnyAsync(p => p.OrdenCompraID == id);
        }
        private async Task<bool> Insertar(OrdenCompra ordenCompra)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.ordenCompra.Add(ordenCompra);
            return await contexto.SaveChangesAsync() > 0;
        }
        private async Task<bool> Modificar(OrdenCompra ordenCompra)
        {
            await using var _context = await DbFactory.CreateDbContextAsync();
            var local = _context.ordenCompra.Local
                .FirstOrDefault(p => p.OrdenCompraID == ordenCompra.OrdenCompraID);
            _context.Entry(ordenCompra).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> Guardar(OrdenCompra ordenCompra)
        {
            if (!await Existe(ordenCompra.OrdenCompraID))
                return await Insertar(ordenCompra);
            else
                return await Modificar(ordenCompra);
        }
        public async Task<bool> Eliminar(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            var cxp = await contexto.ordenCompra
                .Where(p => p.OrdenCompraID == id).ExecuteDeleteAsync();
            return cxp > 0;
        }
        public async Task<OrdenCompra?> Buscar(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.ordenCompra.AsNoTracking().
                FirstOrDefaultAsync(p => p.OrdenCompraID == id);
        }
        public async Task<List<OrdenCompra>> Listar(Expression<Func<OrdenCompra, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.ordenCompra.AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }

    }
}
