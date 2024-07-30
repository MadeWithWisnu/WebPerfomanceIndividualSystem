using PerformanceIndividualDataAccess.Models;

namespace PerformanceIndividualBusiness.Interfaces
{
    public interface IAccountRepository
    {
        public User Get(string username);
        public void Insert(User user);
        public void Update(User user);
        public void Delete(User user);
    }
}
