
using System.ComponentModel.DataAnnotations.Schema;

namespace RVTR.Account.DataContext.DTOModels
{
  public class AddressDTO : DataModel
  {
    public AddressDTO()
    {
    }
    public int Id { get; set; }

    public string City { get; set; }
    

    public string Country { get; set; }
    

    public string PostalCode { get; set; }
    

    public string StateProvince { get; set; }
    

    public string Street { get; set; }
    

    [ForeignKey("Account")]
    public int? AccountId { get; set; }

    public AccountDTO Account { get; set; }
  }
}
