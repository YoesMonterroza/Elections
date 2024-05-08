using Microsoft.EntityFrameworkCore;
using Elections.Backend.Data;
using Elections.Backend.Repositories.Interfaces;
using Elections.Shared.Entities;
using Elections.Shared.Responses;
using Elections.Shared.DTOs;
using Elections.Backend.Helpers;
 
namespace Elections.Backend.Repositories.Implementations
{
    public class SexesRepository : ISexesRepository
    {
        private readonly DataContext _context;

        public SexesRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ActionResponse<IEnumerable<Sex>>> GetAsync(PaginationDTO pagination)
        {
            var queryable = _context.Sexes.AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.Name.ToLower().Contains(pagination.Filter.ToLower()));
            }

            return new ActionResponse<IEnumerable<Sex>>
            {
                WasSuccess = true,
                Result = await queryable
                    .OrderBy(x => x.Name)
                    .Paginate(pagination)
                    .ToListAsync()
            };
        }


        public async Task<ActionResponse<Sex>> PostAsync(SexDTO model)
        {
            Sex sex = new Sex();
            sex.Name = model.Name;
            _context.Add(sex);

            try
            {
                await _context.SaveChangesAsync();
                return new ActionResponse<Sex>
                {
                    WasSuccess = true,
                    Result = sex
                };
            }
            catch (DbUpdateException ex)
            {
                return new ActionResponse<Sex>
                {
                    WasSuccess = false,
                    Result = sex,
                    Message = ex.ToString()
                };
            }
        }

        public async Task<ActionResponse<Sex>> UpdateAsync(Sex model)
        {
            try
            {
                Sex sex = new Sex();
                var result = _context.Sexes.Where(x => x.Id == model.Id).FirstOrDefault();
                if (result != null)
                {
                    sex = result;
                    sex.Name = model.Name;
                    _context.Update(sex);
                    await _context.SaveChangesAsync();

                    return new ActionResponse<Sex>
                    {
                        WasSuccess = true,
                        Result = sex
                    };
                }
                else
                {
                    return new ActionResponse<Sex>
                    {
                        WasSuccess = false,
                        Result = sex
                    };

                }
            }
            catch (DbUpdateException ex)
            {
                return new ActionResponse<Sex>
                {
                    WasSuccess = false,
                    Message = ex.ToString()
                };
            }
        }


        public async Task<ActionResponse<Sex>> DeleteAsync(int id)
        {
            var row = await _context.Sexes.FindAsync(id);
            if (row == null)
            {
                return new ActionResponse<Sex>
                {
                    WasSuccess = false,
                    Message = "Registro no encontrado"
                };
            }

            try
            {
                _context.Sexes.Remove(row);
                await _context.SaveChangesAsync();
                return new ActionResponse<Sex>
                {
                    WasSuccess = true
                };
            }
            catch
            {
                return new ActionResponse<Sex>
                {
                    WasSuccess = false,
                    Message = "No se puede borrar, porque tiene registros relacionados"
                };
            }
        }


    }
}
