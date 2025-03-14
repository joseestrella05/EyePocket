using System.Linq.Expressions;
using EyePocket.Data;
using EyePocket.Models;
using Microsoft.EntityFrameworkCore;

namespace EyePocket.Service;

public class CitasService (IDbContextFactory<ApplicationDbContext> DbFactory)
{
    
        public async Task<bool> Existe(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Citas.AnyAsync(c => c.Id == id);
        }
        private async Task<bool> Insertar(Citas cita)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Citas.Add(cita);
            return await contexto.SaveChangesAsync() > 0;
        }
        private async Task<bool> Modificar(Citas cita)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            var local = contexto.Citas.Local.FirstOrDefault(c => c.Id == cita.Id);
            contexto.Entry(cita).State = EntityState.Modified;
            return await contexto.SaveChangesAsync() > 0;
        }
        public async Task<bool> Guardar(Citas cita)
        {
            if (!await Existe(cita.Id))
                return await Insertar(cita);
            else
                return await Modificar(cita);
        }
        public async Task<bool> Eliminar(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            var citasEliminadas = await contexto.Citas.Where(c => c.Id == id).ExecuteDeleteAsync();
            return citasEliminadas > 0;
        }
        public async Task<Citas?> Buscar(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Citas.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task<List<Citas>> Listar(Expression<Func<Citas, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Citas.AsNoTracking().Where(criterio).ToListAsync();
        }
    }

