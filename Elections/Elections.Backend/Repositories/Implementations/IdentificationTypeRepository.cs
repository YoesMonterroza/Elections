using Microsoft.EntityFrameworkCore;
using Elections.Backend.Data;
using Elections.Backend.Repositories.Interfaces;
using Elections.Shared.Entities;
using Elections.Shared.Responses;
using Elections.Shared.DTOs;
using Elections.Backend.Helpers;
 
namespace Elections.Backend.Repositories.Implementations
{
    public class IdentificationTypeRepository : IIdentificationTypeRepository
    {
        private readonly DataContext _context;

        public IdentificationTypeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ActionResponse<IEnumerable<IdentificationType>>> GetAsync(PaginationDTO pagination)
        {
            var queryable = _context.IdentificationTypes.AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.Name.ToLower().Contains(pagination.Filter.ToLower()));
            }

            return new ActionResponse<IEnumerable<IdentificationType>>
            {
                WasSuccess = true,
                Result = await queryable
                    .OrderBy(x => x.Name)
                    .Paginate(pagination)
                    .ToListAsync()
            };
        }


        public async Task<ActionResponse<IdentificationType>> PostAsync(IdentificationType model)
        {            
            _context.Add(model);

            try
            {
                await _context.SaveChangesAsync();
                return new ActionResponse<IdentificationType>
                {
                    WasSuccess = true,
                    Result = model
                };
            }
            catch (DbUpdateException ex)
            {
                return new ActionResponse<IdentificationType>
                {
                    WasSuccess = false,
                    Result = model,
                    Message = ex.ToString()
                };
            }
        }

        public async Task<ActionResponse<IdentificationType>> UpdateAsync(IdentificationType model)
        {
            try
            {
                IdentificationType models = new IdentificationType();
                var result = _context.IdentificationTypes.Where(x => x.Id == model.Id).FirstOrDefault();
                if (result != null)
                {
                    models = result;
                    models.Name = model.Name;
                    _context.Update(model);
                    await _context.SaveChangesAsync();

                    return new ActionResponse<IdentificationType>
                    {
                        WasSuccess = true,
                        Result = models
                    };
                }
                else
                {
                    return new ActionResponse<IdentificationType>
                    {
                        WasSuccess = false,
                        Result = models
                    };

                }
            }
            catch (DbUpdateException ex)
            {
                return new ActionResponse<IdentificationType>
                {
                    WasSuccess = false,
                    Message = ex.ToString()
                };
            }
        }


        public async Task<ActionResponse<IdentificationType>> DeleteAsync(int id)
        {
            var row = await _context.Users.FindAsync(id);
            if (row == null)
            {
                return new ActionResponse<IdentificationType>
                {
                    WasSuccess = false,
                    Message = "Registro no encontrado"
                };
            }

            try
            {
                _context.Users.Remove(row);
                await _context.SaveChangesAsync();
                return new ActionResponse<IdentificationType>
                {
                    WasSuccess = true
                };
            }
            catch
            {
                return new ActionResponse<IdentificationType>
                {
                    WasSuccess = false,
                    Message = "No se puede borrar, porque tiene registros relacionados"
                };
            }
        }


    }
}
