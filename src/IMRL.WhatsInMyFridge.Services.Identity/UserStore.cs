using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IMRL.WhatsInMyFridge.Core;
using IMRL.WhatsInMyFridge.Core.Identity;
using IMRL.WhatsInMyFridge.DataAccess;
using IMRL.WhatsInMyFridge.DataAccess.Repositories;


namespace IMRL.WhatsInMyFridge.Services.Identity
{
    public class UserStore : IUserPasswordStore<User>
    {
        private readonly IDataRepository _dataRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserStore(IDataRepository dataRepository, IUnitOfWork unitOfWork)
        {
            _dataRepository = dataRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken)
        {
            _dataRepository.Insert(user);
            _unitOfWork.Commit();
            return Task.FromResult(IdentityResult.Success);
        }

        public Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken)
        {
            _dataRepository.Delete(user);
            _unitOfWork.Commit();
            return Task.FromResult(IdentityResult.Success);
        }

        public void Dispose()
        {
        }

        public Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            Guid id = Guid.Empty;
            Guid.TryParse(userId, out id);
            var user = _dataRepository.Query<User>()
                .SingleOrDefault(u => u.Id == id);
            return Task.FromResult(user);
        }

        public Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            var user = _dataRepository.Query<User>()
                .SingleOrDefault(u => u.Username == normalizedUserName);

            return Task.FromResult(user);
        }

        public Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Username.ToLower());
        }

        public Task<string> GetPasswordHashAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.PasswordHash);
        }

        public Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Id.ToString());
        }

        public Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Username);
        }

        public Task<bool> HasPasswordAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(!String.IsNullOrEmpty(user.PasswordHash));
        }

        public Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken)
        {
            user.Username = normalizedName;
            return Task.CompletedTask;
        }

        public Task SetPasswordHashAsync(User user, string passwordHash, CancellationToken cancellationToken)
        {
            user.PasswordHash = passwordHash;
            return Task.CompletedTask;
        }

        public Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken)
        {
            user.Username = userName;
            return Task.CompletedTask;
        }

        public Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
        {
            var dbUser = _dataRepository.Query<User>()
                .Single(u => u.Id == user.Id);
            dbUser.Email = user.Email;
            dbUser.PasswordHash = user.PasswordHash;
            dbUser.Username = user.Username;
            _dataRepository.Update(dbUser);
            _unitOfWork.Commit();
            return Task.FromResult(IdentityResult.Success);
        }
    }
}
