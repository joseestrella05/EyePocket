namespace EyePocket.Service
{
    using System.Linq.Expressions;
    using EyePocket.Data;
    using EyePocket.Models;
    using Microsoft.EntityFrameworkCore;

    public class CategoriaService
    {
        private readonly IDbContextFactory<ApplicationDbContext> DbFactory;

        public CategoriaService(IDbContextFactory<ApplicationDbContext> dbFactory)
        {
            DbFactory = dbFactory;
        }

        // 1️⃣ Verificar si existe una categoría por ID
        public async Task<bool> Existe(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Categorias.AnyAsync(c => c.CategoriaId == id);
        }

        // 2️⃣ Modificar una categoría
        public async Task<bool> Modificar(Categoria categoria)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Update(categoria);
            return await contexto.SaveChangesAsync() > 0;
        }

        // 3️⃣ Insertar una nueva categoría
        public async Task<bool> Insertar(Categoria categoria)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Categorias.Add(categoria);
            return await contexto.SaveChangesAsync() > 0;
        }

        // 4️⃣ Guardar (insertar o modificar) una categoría
        public async Task<bool> Guardar(Categoria categoria)
        {
            if (!await Existe(categoria.CategoriaId))
                return await Insertar(categoria);
            else
                return await Modificar(categoria);
        }

        // 5️⃣ Eliminar una categoría por ID
        public async Task<bool> Eliminar(int categoriaId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Categorias
                .Where(c => c.CategoriaId == categoriaId)
                .ExecuteDeleteAsync() > 0;
        }

        // 6️⃣ Listar categorías según un criterio
        public async Task<List<Categoria>> Listar(Expression<Func<Categoria, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Categorias
                .Where(criterio)
                .ToListAsync();
        }

        // 7️⃣ Buscar una categoría por ID
        public async Task<Categoria?> BuscarId(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Categorias
                .FirstOrDefaultAsync(c => c.CategoriaId == id);
        }
    }
}