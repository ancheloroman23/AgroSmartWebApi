﻿using AgroSmart.Core.Application.Dtos.Accounts;

namespace AgroSmart.Core.Application.Interfaces.Services
{
    public interface IAccountService
    {
        #region ChangePassword
        Task<ForgotPasswordResponse> ForgotPasswordAsync(ForgotPasswordRequest request, string origin);
        Task<ResetPasswordResponse> ResetPasswordAsync(ResetPasswordRequest request);
        Task ChangePasswordAsync(string userid, string password);

        #endregion

        #region Register and Authentication
        Task<RegisterResponse> RegisterAsync(RegisterRequest request, string? origin);
        Task<AuthenticationResponse> AuthenticateWebApiAsync(AuthenticationRequest request);        
        Task<string> ConfirmAccountAsync(string userId, string token);

        Task SignOutAsync();

        #endregion

        #region Update
        Task ChangeStatusAsync(string id, bool status);
        Task<RegisterResponse> UpdateAsync(UpdateUserRequest request, string id);
        #endregion

        #region Gets
        Task<List<AuthenticationResponse>> GetAllAsync(string entity);
        Task<AuthenticationResponse> GetUserByIdAsync(string id);
        #endregion

        #region Delete
        Task DeleteAsync(string id);
        #endregion

        #region CheckPassword
        Task<bool> CheckOldPassword(string oldPassword, string userId);
        #endregion        
    }
}
