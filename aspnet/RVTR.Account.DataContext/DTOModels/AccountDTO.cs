
using System.Collections.Generic;

namespace RVTR.Account.DataContext.DTOModels
{
  public class AccountDTO : DataModel
  {
    public AccountDTO()
    {
    }

    public int Id { get; set; }

    public AddressDTO Address { get; set; }

    public string Name { get; set; }
    

    public IEnumerable<PaymentDTO> Payments { get; set; }

    public IEnumerable<ProfileDTO> Profiles { get; set; }
  }
}
