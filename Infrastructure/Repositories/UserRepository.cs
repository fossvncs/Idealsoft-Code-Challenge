

using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        #region [Properties&Constructor]
        private readonly MyDbContext _context;
        public UserRepository(MyDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        #endregion

        #region [Gets]
        public async Task<List<User>> GetAllUsers()
        {
            var response = await _context.Users.ToListAsync();
            return response;
        }

        public async Task<User> GetById(int id)
        {
            var user = await _context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
            return user;
        }
        #endregion

        #region [Post]
        public async Task<User> CreateUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }
        #endregion

        #region [Put]
        public async Task<User> UpdateUser(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }
        #endregion

        #region [Delete]
        public async Task<bool> DeleteUser(int id)
        {
            var user = await _context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (user == null)
            {
                return false;
            }
            else
            {
                // Removendo o registro do banco de dados
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();  // Salva as mudanças no banco de dados
                return true;
            }
        }
        #endregion

    }
}
