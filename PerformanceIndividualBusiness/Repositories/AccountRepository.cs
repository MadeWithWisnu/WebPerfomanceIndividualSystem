using Microsoft.EntityFrameworkCore;
using PerformanceIndividualBusiness.Interfaces;
using PerformanceIndividualDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using WebPerfomanceIndividualSystem.Models;

namespace PerformanceIndividualBusiness.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly PerformanceAppsContext _dbContext;
        public AccountRepository(PerformanceAppsContext dbContext) { _dbContext = dbContext; }
        public User Get(string username)
        {
            return _dbContext.Users.Find(username)
            ?? throw new Exception("Username tidak ada di database");
        }

        public void Insert(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }
        public void Update(User user)
        {
            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
        }

        public void Delete(User user)
        {
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }
    }
}
