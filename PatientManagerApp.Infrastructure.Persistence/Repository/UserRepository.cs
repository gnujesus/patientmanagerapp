using Microsoft.EntityFrameworkCore;
using PatientManagerApp.Core.Application.Helpers;
using PatientManagerApp.Core.Application.Interfaces.Repositories;
using PatientManagerApp.Core.Application.ViewModels.User;
using PatientManagerApp.Core.Domain.Entities;
using PatientManagerApp.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagerApp.Infrastructure.Persistence.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ApplicationContext _dbContext;
        public UserRepository(ApplicationContext dbContext) : base(dbContext) {
            _dbContext = dbContext;
        }

        public async Task<User> LoginAsync(LoginUserViewModel loginUserViewModel)
        {
            string encryptedPassword = EncryptationHelper.ComputeSha256Hash(loginUserViewModel.Password);
            User user = await _dbContext.Set<User>().FirstOrDefaultAsync(user => user.Username == loginUserViewModel.Username && user.Password == encryptedPassword);

            // return null if not found
            return user;
        }
    }
}
