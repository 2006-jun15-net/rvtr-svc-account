using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RVTR.Account.DataContext.DTOModels;
using RVTR.Account.ObjectModel.Models;

namespace RVTR.Account.DataContext.Repositories 
{
  /// <summary>
  /// Represents the _Repository_ generic
  /// </summary>
  /// <typeparam name="TEntity"></typeparam>
  public class Repository<TEntity, DTOTEntity>
    where TEntity : BaseBusinessModel, new()
    where DTOTEntity : DataModel, new()
  {
    public readonly DbSet<DTOTEntity> _db;
    public readonly IMapper _mapper;

    public Repository(AccountContext context)
    {
      _db = context.Set<DTOTEntity>();

      var config = new MapperConfiguration (cfg =>
      {
        cfg.CreateMap<AccountModel, AccountDTO>();
        cfg.CreateMap<AccountDTO, AccountModel>();

        cfg.CreateMap<AddressModel, AddressDTO>();
        cfg.CreateMap<AddressDTO, AddressModel>();

        cfg.CreateMap<BankCardModel, BankCardDTO>();
        cfg.CreateMap<BankCardDTO, BankCardModel>();

        cfg.CreateMap<NameModel, NameDTO>();
        cfg.CreateMap<NameDTO, NameModel>();

        cfg.CreateMap<PaymentModel, PaymentDTO>();
        cfg.CreateMap<PaymentDTO, PaymentModel>();

        cfg.CreateMap<ProfileModel, ProfileDTO>();
        cfg.CreateMap<ProfileDTO, ProfileModel>();
      });

      _mapper = config.CreateMapper();
      
    }

    //public virtual async Task DeleteAsync(int id)
    //{
    //  var dataObject =
    //  _db.Remove(await SelectAsync(id));
    //}

    public virtual async Task InsertAsync(TEntity entry)
    {
      var dataObject = _mapper.Map<DTOTEntity>(entry);
      await _db.AddAsync(dataObject).ConfigureAwait(true);
    }



    public virtual async Task<IEnumerable<TEntity>> SelectAsync()
    {
      var dataObjects = await _db.ToListAsync();
      return _mapper.Map<IEnumerable<TEntity>>(dataObjects);
    }

    public virtual async Task<TEntity> SelectAsync(int id)
    {
      var dataObject = await _db.FindAsync(id).ConfigureAwait(true);
      return _mapper.Map<TEntity>(dataObject);
    }


    public virtual void Update(TEntity entry)
    {
      var dataObject = _mapper.Map<DTOTEntity>(entry);
      _db.Update(dataObject);
    }
  }
}
