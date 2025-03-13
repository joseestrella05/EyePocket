namespace EyePocket.Service
{
    using System.Linq.Expressions;
    using EyePocket.Data;
    using EyePocket.Models;
    using Microsoft.EntityFrameworkCore;
    public class MermasService(IDbContextFactory<ApplicationDbContext> DbFactory)
    {
        // 1️⃣ Verificar si existe una merma por ID
        public async Task<bool> Existe(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Mermas.AnyAsync(m => m.MermaId == id);
        }

        // 2️⃣ Modificar una merma
        public async Task<bool> Modificar(Mermas merma)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Update(merma);
            return await contexto.SaveChangesAsync() > 0;
        }

        // 3️⃣ Insertar una nueva merma
        public async Task<bool> Insertar(Mermas merma)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Mermas.Add(merma);
            return await contexto.SaveChangesAsync() > 0;
        }

        // 4️⃣ Guardar (insertar o modificar)
        public async Task<bool> Guardar(Mermas merma)
        {
            if (!await Existe(merma.MermaId))
                return await Insertar(merma);
            else
                return await Modificar(merma);
        }

        // 5️⃣ Eliminar una merma por ID
        public async Task<bool> Eliminar(int mermaId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Mermas
                .Where(m => m.MermaId == mermaId)
                .ExecuteDeleteAsync() > 0;
        }

        // 6️⃣ Listar mermas según un criterio
        public async Task<List<Mermas>> Listar(Expression<Func<Mermas, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Mermas
                .Where(criterio)
                .Include(m => m.Producto) // Para traer la información del producto asociado
                .ToListAsync();
        }

        // 7️⃣ Buscar una merma por ID
        public async Task<Mermas?> BuscarId(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Mermas
                .Include(m => m.Producto) // Incluye el producto relacionado
                .FirstOrDefaultAsync(m => m.MermaId == id);
        }
    }
}
