using System.Threading.Tasks;
using RVTR.Account.DataContext.DTOModels;
using RVTR.Account.ObjectModel.Models;

namespace RVTR.Account.DataContext.Repositories
{
    /// <summary>
    /// Represents the _UnitOfWork_ repository
    /// </summary>
    public class UnitOfWork
    {
        private readonly AccountContext _context;

        public virtual AccountRepository Account { get; }
        public virtual Repository<ProfileModel, ProfileDTO> Profile { get; }
        public virtual Repository<AddressModel, AddressDTO> Address { get; }

        public UnitOfWork(AccountContext context)
        {
            _context = context;

            Account = new AccountRepository(context);
            Profile = new Repository<ProfileModel, ProfileDTO>(context);
            Address = new Repository<AddressModel, AddressDTO>(context);
        }

        /// <summary>
        /// Represents the _UnitOfWork_ `Commit` method
        /// </summary>
        /// <returns></returns>
        public async Task<int> CommitAsync() => await _context.SaveChangesAsync();
    }
}
