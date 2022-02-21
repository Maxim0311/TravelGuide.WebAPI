using TravelGuide.Domain.Entities;
using TravelGuide.Domain.Models;

namespace TravelGuide.Domain.Services
{
    public interface IUserService
    {
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest model);
        Task<IEnumerable<User>> GetAll();
        Task<User?> GetById(int id);
        Task<AuthenticateResponse?> Registration(RegistrationRequest model);
    }
}
