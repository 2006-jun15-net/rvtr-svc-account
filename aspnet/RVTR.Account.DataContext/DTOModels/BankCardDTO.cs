using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RVTR.Account.DataContext.DTOModels
{
  public class BankCardDTO : DataModel
  {
    public BankCardDTO()
    {
    }
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public DateTime Expiry { get; set; }

    public string Number { get; set; }
    
  }
}
