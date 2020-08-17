
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RVTR.Account.DataContext.DTOModels
{
  public class PaymentDTO : DataModel
  {
    public PaymentDTO()
    {
    }
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public BankCardDTO BankCard { get; set; }

    public string Name { get; set; }
    
  }
}
