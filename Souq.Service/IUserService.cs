using Souq.ViewModels;
using System.Collections.Generic;

namespace Souq.Service
{
    public interface IUserService
    {
        Response<string> Login(UserCreateViewModel viewModel);
        Response<string> Register(UserCreateViewModel viewModel);
        Response<UserViewModel> GetUserById(int id);


    }
}