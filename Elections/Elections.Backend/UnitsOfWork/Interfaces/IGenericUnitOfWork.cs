﻿using Elections.Shared.DTOs;
using Elections.Shared.Responses;

namespace Elections.Backend.UnitsOfWork.Interfaces
{

        public interface IGenericUnitOfWork<T> where T : class
        {
        Task<ActionResponse<T>> AddAsync(T model);

        Task<ActionResponse<T>> DeleteAsync(int id);

        Task<ActionResponse<IEnumerable<T>>> GetAsync();
        Task<ActionResponse<T>> GetAsync(int id);

        Task<ActionResponse<T>> UpdateAsync(T model);
        Task<ActionResponse<IEnumerable<T>>> GetAsync(PaginationDTO pagination);

        Task<ActionResponse<int>> GetTotalPagesAsync(PaginationDTO pagination);

    }
}
