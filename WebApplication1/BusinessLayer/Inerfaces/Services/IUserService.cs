using Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Inerfaces.Services
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetAllAsync();
        Task<UserDTO?> GetByPublicIdAsync(Guid publicId);
        Task<UserDTO?> GetByIdAsync(int id);    
        Task<bool> CreateAsync(UserDTO model);
        Task<bool> UpdateAsync(UserDTO model);
        Task<bool> DeleteAsync(Guid publicId);
    }
}
