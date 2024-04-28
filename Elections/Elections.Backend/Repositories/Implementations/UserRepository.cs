using Microsoft.EntityFrameworkCore;
using Elections.Backend.Data;
using Elections.Backend.Repositories.Interfaces;
using Elections.Shared.Entities;
using Elections.Shared.Responses;
using Elections.Shared.DTOs;
using Elections.Backend.Helpers;
 
namespace Elections.Backend.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ActionResponse<IEnumerable<User>>> GetAsync(PaginationDTO pagination)
        {
            var queryable = _context.Users.AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.Name.ToLower().Contains(pagination.Filter.ToLower()));
            }

            return new ActionResponse<IEnumerable<User>>
            {
                WasSuccess = true,
                Result = await queryable
                    .OrderBy(x => x.Name)
                    .Paginate(pagination)
                    .ToListAsync()
            };
        }


        public async Task<ActionResponse<User>> PostAsync(UserDTO model)
        {
            User user = new User();
            user.Name = model.Name;
            user.LastName = model.LastName;
            user.BirthDate = model.BirthDate;
            user.SexId = model.SexId;
            _context.Add(user);

            try
            {
                await _context.SaveChangesAsync();
                return new ActionResponse<User>
                {
                    WasSuccess = true,
                    Result = user
                };
            }
            catch (DbUpdateException ex)
            {
                return new ActionResponse<User>
                {
                    WasSuccess = false,
                    Result = user,
                    Message = ex.ToString()
                };
            }
        }

        public async Task<ActionResponse<User>> UpdateAsync(User model)
        {
            try
            {
                User user = new User();
                var result = _context.Users.Where(x => x.Id == model.Id).FirstOrDefault();
                if (result != null)
                {
                    user = result;
                    user.Name = model.Name;
                    _context.Update(user);
                    await _context.SaveChangesAsync();

                    return new ActionResponse<User>
                    {
                        WasSuccess = true,
                        Result = user
                    };
                }
                else
                {
                    return new ActionResponse<User>
                    {
                        WasSuccess = false,
                        Result = user
                    };

                }
            }
            catch (DbUpdateException ex)
            {
                return new ActionResponse<User>
                {
                    WasSuccess = false,
                    Message = ex.ToString()
                };
            }
        }


        public async Task<ActionResponse<User>> DeleteAsync(int id)
        {
            var row = await _context.Users.FindAsync(id);
            if (row == null)
            {
                return new ActionResponse<User>
                {
                    WasSuccess = false,
                    Message = "Registro no encontrado"
                };
            }

            try
            {
                _context.Users.Remove(row);
                await _context.SaveChangesAsync();
                return new ActionResponse<User>
                {
                    WasSuccess = true
                };
            }
            catch
            {
                return new ActionResponse<User>
                {
                    WasSuccess = false,
                    Message = "No se puede borrar, porque tiene registros relacionados"
                };
            }
        }


    }
}
