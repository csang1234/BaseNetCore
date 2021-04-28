using CtrlShiftH.Data.Entities;
using CtrlShiftH.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace CtrlShiftH.Services.Catalog
{
    public interface IAuthService
    {
        //Task<LoginViewModel> Login(UserLoginRequest request);
        //Task<UserViewModel> Register(UserRegisterRequest request);
        //Task<bool> ChangePassword(ChangePasswordViewModel request);
        //Task<bool> ResetPasswordToDefault(Guid userId);
        Task<ResultModel> LoginWithFacebookAsync(string accessToken);
    }

    public class AuthService : IAuthService
    {
        private readonly IFacebookAuthService _facebookAuthService;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IConfiguration _config;

        public AuthService(IFacebookAuthService facebookAuthService, IConfiguration config, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _facebookAuthService = facebookAuthService;
            _config = config;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public async Task<ResultModel> LoginWithFacebookAsync(string accessToken)
        {
            var rs = new ResultModel();
            try
            {
                var validatedTokenResult = await _facebookAuthService.ValidateAccessTokenAsync(accessToken);
                if (!validatedTokenResult.data.is_valid)
                {
                    rs.Succeed = false;
                    rs.ErrorMessage = "Error";
                    return rs;
                }
                var userInfo = await _facebookAuthService.GetUserInfoResult(accessToken);

                var user = await _userManager.FindByIdAsync(userInfo.id);

                rs.Succeed = true;
                rs.Data = "success";

                return null;
            }
            catch (Exception e)
            {
                rs.Succeed = false;
                rs.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
                return rs;
            }
        }
    }
}