namespace EyePocket.Service
{
    using System.Linq.Expressions;
    using EyePocket.Data;
    using EyePocket.Models;
    using Microsoft.EntityFrameworkCore;

    public class DistribucionInventarioService(IDbContextFactory<ApplicationDbContext> DbFactory)
    {
        // 1️⃣ Verificar si existe una distribución por ID
        public async Task<bool> Existe(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.DistribucionInventario.AnyAsync(d => d.DistribucionId == id);
        }

        public async Task<bool> Modificar(DistribucionInventario distribucion)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.DistribucionInventario.Update(distribucion);  // Se actualiza la distribución
            return await contexto.SaveChangesAsync() > 0;  // Se guarda y se verifica si la operación fue exitosa
        }


        // 3️⃣ Insertar una nueva distribución
        public async Task<bool> Insertar(DistribucionInventario distribucion)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.DistribucionInventario.Add(distribucion);
            return await contexto.SaveChangesAsync() > 0;
        }

        // 4️⃣ Guardar (insertar o modificar)
        public async Task<bool> Guardar(DistribucionInventario distribucion)
        {
            if (!await Existe(distribucion.DistribucionId))
                return await Insertar(distribucion);
            else
                return await Modificar(distribucion);
        }

        public async Task<bool> Eliminar(DistribucionInventario distribucion)
        {
            // Obtener el contexto de la base de datos
            await using var contexto = await DbFactory.CreateDbContextAsync();

            // Buscar la distribución a eliminar por su ID
            var distribucionExistente = await contexto.DistribucionInventario
                .FirstOrDefaultAsync(d => d.DistribucionId == distribucion.DistribucionId);

            // Verificar si la distribución existe
            if (distribucionExistente != null)
            {
                // Eliminar la distribución
                contexto.DistribucionInventario.Remove(distribucionExistente);

                // Guardar los cambios en la base de datos
                return await contexto.SaveChangesAsync() > 0;
            }

            // Si no se encontró la distribución, retornar false
            return false;
        }



        // 6️⃣ Listar distribuciones según un criterio
        public async Task<List<DistribucionInventario>> Listar(Expression<Func<DistribucionInventario, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.DistribucionInventario
                .Where(criterio)
                .Include(d => d.Producto) // Para traer la información del producto asociado
                .ToListAsync();
        }

        // 7️⃣ Buscar una distribución por ID
        public async Task<DistribucionInventario?> BuscarId(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.DistribucionInventario
                .Include(d => d.Producto)
                .FirstOrDefaultAsync(d => d.DistribucionId == id);
        }

        public async Task<List<DistribucionInventario>> ObtenerDistribucionesPorProducto(int productoId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.DistribucionInventario
                .Where(d => d.ProductoId == productoId)
                .ToListAsync();
        }

    }
}