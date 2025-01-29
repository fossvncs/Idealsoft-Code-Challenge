

using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Interfaces;

namespace Application
{
    public class UserApplication : IUserApplication
    {
        #region [Properties&Constructor]
        private readonly IUserRepository _repository;
        public UserApplication(IUserRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        #endregion

        #region [Gets]


        public async Task<List<User>> GetAllUsers()
        {
            try
            {
                var response = await _repository.GetAllUsers();
                return response.ToList();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while trying to get all users.", ex);
            }
        }

        public async Task<User> GetById(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ApplicationException("The id must be above 0!");
                }
                else
                {
                    var response = await _repository.GetById(id);
                    return response;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while processing your request.", ex);
            }
        }

        #endregion

        #region [Post]
        public async Task<User> CreateUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            if (string.IsNullOrWhiteSpace(user.Name) ||
                string.IsNullOrWhiteSpace(user.Surname) ||
                string.IsNullOrWhiteSpace(user.Phone))
            {
                throw new ApplicationException("All fields (Name, Surname, Phone) must be provided.");
            }

            // setting the id to 0 to avoid problems
            user.Id = 0;

            try
            {               
                var createdUser = await _repository.CreateUser(user);
                return createdUser; 
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"An error occurred while creating the user: {ex.Message}", ex);
            }
        }
        #endregion

        #region [Put]
        public async Task<User> UpdateUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            if (string.IsNullOrWhiteSpace(user.Name) ||
                string.IsNullOrWhiteSpace(user.Surname) ||
                string.IsNullOrWhiteSpace(user.Phone))
            {
                throw new ApplicationException("All fields (Name, Surname, Phone) must be provided.");
            }

            try
            {
                var existingUser = await _repository.GetById(user.Id);
                if (existingUser == null)
                    throw new ApplicationException($"User with ID {user.Id} not found.");

                existingUser.Name = user.Name;
                existingUser.Surname = user.Surname;
                existingUser.Phone = user.Phone;

                var updatedUser = await _repository.UpdateUser(existingUser);

                return updatedUser;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"An error occurred while updating the user: {ex.Message}", ex);
            }
        }
        #endregion

        #region [Delete]
        public async Task<bool> DeleteUser(int id)
        {
            if (id <= 0)
            {
                return false;
                throw new ApplicationException("The id must be above 0!");
            }
            else
            {
                return await _repository.DeleteUser(id);
            }
        }

        #endregion


    }
}
