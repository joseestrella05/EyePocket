using EyePocket.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using EyePocket.Data;

namespace EyePocket.Service
{
    public class ProductosService(IDbContextFactory<ApplicationDbContext> DbFactory)
    {
        // 1️⃣ Método para verificar si existe un producto por ID
        public async Task<bool> Existe(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Productos.AnyAsync(p => p.ProductoId == id);
        }

        // 2️⃣ Método para modificar un producto
        public async Task<bool> Modificar(Productos producto)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Update(producto);
            return await contexto.SaveChangesAsync() > 0;
        }

        // 3️⃣ Método para insertar un nuevo producto
        public async Task<bool> Insertar(Productos producto)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Productos.Add(producto);
            return await contexto.SaveChangesAsync() > 0;
        }

        // 4️⃣ Método para guardar (insertar o modificar)
        public async Task<bool> Guardar(Productos producto)
        {
            if (!await Existe(producto.ProductoId))
                return await Insertar(producto);
            else
                return await Modificar(producto);
        }

        // 5️⃣ Método para eliminar un producto por ID
        public async Task<bool> Eliminar(int productoId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Productos
                .Where(p => p.ProductoId == productoId)
                .ExecuteDeleteAsync() > 0;
        }

        // 6️⃣ Método para listar productos según un criterio
        public async Task<List<Productos>> Listar(Expression<Func<Productos, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Productos.Include(p => p.Proveedor)
                .Where(criterio)
                .ToListAsync();
        }

        // 7️⃣ Método para buscar un producto por nombre
        public async Task<Productos?> BuscarNombre(string nombre)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Productos.FirstOrDefaultAsync(p => p.Nombre == nombre);
        }
        // 7️⃣ Método para buscar un producto por Codigo
        public async Task<Productos?> BuscarCodigo(string codigo)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Productos.FirstOrDefaultAsync(p => p.Codigo == codigo);
        }

        // 8️⃣ Método para buscar un producto por ID
        public async Task<Productos?> BuscarId(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Productos.FirstOrDefaultAsync(p => p.ProductoId == id);
        }
        
    }
}
