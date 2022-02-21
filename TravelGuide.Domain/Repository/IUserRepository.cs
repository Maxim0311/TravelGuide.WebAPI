using TravelGuide.Domain.Entities;

namespace TravelGuide.Domain.Repository
{
    public interface IUserRepository
    {
        Task<User?> Get(int id);
        Task<User?> Get(string userName);
        Task<User?> Get(string userName, string password);
        Task<IEnumerable<User>> GetAll();
        Task Add(User user);
    }
}
