using AutoMapper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Souq.Database;
using Souq.Models;
using Souq.Repository;
using Souq.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Souq.Service
{
    public class UserService : IUserService
    {
        private readonly SouqContext _context;
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;


        public UserService(SouqContext context, IUserRepository repository, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _repository = repository;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        public Response<string> Login(UserCreateViewModel viewModel)
        {
            var user = _repository.GetUserByCredentails(viewModel.Email, viewModel.Password);
            if (user == null)
                return new FailureResponse<string>("404");

            //generate token
            var token = generateJwtToken(_mapper.Map<UserViewModel>(user));
            return new SuccessResponse<string>(token);
        }

        public Response<string> Register(UserCreateViewModel viewModel)
        {
            if (_repository.IsEmailExist(viewModel.Email))
                return new FailureResponse<string>("405");

            var user = _mapper.Map<User>(viewModel);
            _repository.AddUser(user);
            _context.SaveChanges();

            //generate token
            var token = generateJwtToken(_mapper.Map<UserViewModel>(user));
            return new SuccessResponse<string>(token);
        }


        public Response<UserViewModel> GetUserById(int id)
        {
            var user = _repository.GetUserById(id);

            return new SuccessResponse<UserViewModel>(_mapper.Map<UserViewModel>(user));
        }

        private string generateJwtToken(UserViewModel user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.ID.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
