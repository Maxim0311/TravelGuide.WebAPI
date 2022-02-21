using AutoMapper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TravelGuide.Application.Helpers.Auth;
using TravelGuide.Domain.Entities;
using TravelGuide.Domain.Models;
using TravelGuide.Domain.Repository;
using TravelGuide.Domain.Services;

namespace TravelGuide.Application.Services
{
    public class UserService : IUserService
    {
        private readonly AuthSettings _authSettings;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IOptions<AuthSettings> authSettings,
            IUserRepository userRepository,
            IMapper mapper)
        {
            _authSettings = authSettings.Value;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<AuthenticateResponse?> Registration(RegistrationRequest model)
        {
            var user = await _userRepository.Get(model.Username);

            if (user != null) return null;

            var registerUser = _mapper.Map<User>(model);

            await _userRepository.Add(registerUser);

            var authRequest = _mapper.Map<AuthenticateRequest>(model);

            // Аутентификация после успешной регистрации
            return await Authenticate(authRequest);
        }

        public async Task<AuthenticateResponse?> Authenticate(AuthenticateRequest model)
        {
            var user = await _userRepository.Get(model.Username, model.Password);

            if (user == null) return null;

            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _userRepository.GetAll();
        }

        public async Task<User?> GetById(int id)
        {
            return await _userRepository.Get(id);
        }

        private string generateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_authSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
