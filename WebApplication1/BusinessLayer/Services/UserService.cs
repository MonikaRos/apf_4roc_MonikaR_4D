using BusinessLayer.Inerfaces.Repository;
using BusinessLayer.Inerfaces.Services;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserApp.DataLayer.Entities;

namespace BusinessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        
        public async Task<List<UserDTO>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();

            return users.Select(u => new UserDTO
            {
                Id = u.Id,
                PublicId = u.PublicId,
                Name = u.Name,
                Email = u.Email
            }).ToList();
        }

        
        public async Task<UserDTO?> GetByPublicIdAsync(Guid publicId)
        {
            var user = await _userRepository.GetByPublicIdAsync(publicId);

            if (user == null)
                return null;

            return new UserDTO
            {
                Id = user.Id,
                PublicId = user.PublicId,
                Name = user.Name,
                Email = user.Email
            };
        }

       
        public async Task<UserDTO?> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                return null;

            return new UserDTO
            {
                Id = user.Id,
                PublicId = user.PublicId,
                Name = user.Name,
                Email = user.Email
            };
        }

        
        public async Task<bool> CreateAsync(UserDTO model)
        {
            var entity = new UserEntity
            {
                PublicId = Guid.NewGuid(),
                Name = model.Name,
                Email = model.Email
            };

            await _userRepository.CreateAsync(entity);
            await _userRepository.SaveChangesAsync();

            return true;
        }

       
        public async Task<bool> UpdateAsync(UserDTO model)
        {
            var user = await _userRepository.GetByPublicIdAsync(model.PublicId);
            if (user == null)
                return false;

            user.Name = model.Name;
            user.Email = model.Email;

            _userRepository.Update(user);
            await _userRepository.SaveChangesAsync();

            return true;
        }

        
        public async Task<bool> DeleteAsync(Guid publicId)
        {
            var user = await _userRepository.GetByPublicIdAsync(publicId);
            if (user == null)
                return false;

            _userRepository.Delete(user);
            await _userRepository.SaveChangesAsync();

            return true;
        }
    }
}
