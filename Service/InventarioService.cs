using EyePocket.Data;
using EyePocket.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

public class InventarioService(IDbContextFactory<ApplicationDbContext> DbFactory)
{
    public async Task<bool> Existe(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Inventarios.AnyAsync(i => i.InventarioId == id);
    }

    public async Task<bool> Insertar(Inventarios inventario)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        inventario.Stock = inventario.Entradas - inventario.Salidas;
        var producto = await contexto.Productos.FindAsync(inventario.ProductoId);
        if (producto != null)
        {
            inventario.importe = Convert.ToDouble(inventario.Stock * producto.Precio);
        }
        contexto.Inventarios.Add(inventario);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Inventarios inventario)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        inventario.Stock = inventario.Entradas - inventario.Salidas;

        var producto = await contexto.Productos.FindAsync(inventario.ProductoId);
        if (producto != null)
        {
            inventario.importe = Convert.ToDouble(inventario.Stock * producto.Precio);
        }
        contexto.Entry(inventario).State = EntityState.Modified;
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Inventarios inventario)
    {
        if (!await Existe(inventario.InventarioId))
            return await Insertar(inventario);
        else
            return await Modificar(inventario);
    }

    public async Task<bool> Eliminar(int inventarioId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Inventarios
            .Where(i => i.InventarioId == inventarioId)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<List<Inventarios>> Listar(Expression<Func<Inventarios, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Inventarios.Include(i => i.Producto).Where(criterio).ToListAsync();
    }

    public async Task<Inventarios?> BuscarId(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Inventarios.Include(i => i.Producto).FirstOrDefaultAsync(i => i.InventarioId == id);
    }

    public async Task<bool> RegistrarEntrada(int inventarioId, int cantidad)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var inventario = await contexto.Inventarios.FindAsync(inventarioId);
        if (inventario == null) return false;


        inventario.Entradas += cantidad;
        inventario.Stock = inventario.Entradas - inventario.Salidas;

        var producto = await contexto.Productos.FindAsync(inventario.ProductoId);
        if (producto != null)
        {
            inventario.importe = Convert.ToDouble(inventario.Stock * producto.Precio);
        }
        contexto.Entry(inventario).State = EntityState.Modified;
        return await contexto.SaveChangesAsync() > 0;
    }
    public async Task<Inventarios?> ObtenerInventarioPorProducto(int productoId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Inventarios.FirstOrDefaultAsync(i => i.ProductoId == productoId);
    }

}
