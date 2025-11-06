using BusinessLayer.Inerfaces.Services;
using Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserApp.datalayer;
using UserApp.DataLayer.Entities;

namespace BusinessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly AppDbContext _context;

        public UserService(ILogger<UserService> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<List<UserDTO>> GetAllAsync()
        {
            var users = await _context.Users.AsNoTracking().ToListAsync();
            return users.Select(u => new UserDTO
            {
                Id = u.Id,                    // 👈 pridali sme Id
                PublicId = u.PublicId,
                Name = u.Name,
                Email = u.Email
            }).ToList();
        }

        public async Task<UserDTO?> GetByPublicIdAsync(Guid publicId)
        {
            var user = await _context.Users.AsNoTracking()
                .FirstOrDefaultAsync(u => u.PublicId == publicId);

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
            var user = await _context.Users.AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id);

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
            try
            {
                var newUser = new UserEntity
                {
                    PublicId = Guid.NewGuid(),
                    Name = model.Name,
                    Email = model.Email
                };

                _context.Users.Add(newUser);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating user");
                return false;
            }
        }

        public async Task<bool> UpdateAsync(UserDTO model)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.PublicId == model.PublicId);
                if (user == null)
                    return false;

                user.Name = model.Name;
                user.Email = model.Email;

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating user");
                return false;
            }
        }

        public async Task<bool> DeleteAsync(Guid publicId)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.PublicId == publicId);
                if (user == null)
                    return false;

                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting user");
                return false;
            }
        }
    }
}
