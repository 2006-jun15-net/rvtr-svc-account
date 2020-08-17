
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RVTR.Account.DataContext.DTOModels
{
  public class ProfileDTO : DataModel
  {
    public ProfileDTO()
    {
    }
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Email { get; set; }
    

    public NameDTO Name { get; set; }

    public string Phone { get; set; }
    

    [ForeignKey("Account")]
    public int? AccountId { get; set; }

    public AccountDTO Account { get; set; }
  }
}
