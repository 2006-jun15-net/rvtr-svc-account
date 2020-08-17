
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RVTR.Account.DataContext.DTOModels
{
  public class NameDTO : DataModel
  {
    public NameDTO()
    {
    }
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Family { get; set; }
    

    public string Given { get; set; }
    

    public int? ProfileId { get; set; }

    public ProfileDTO Profile { get; set; }
  }
}
