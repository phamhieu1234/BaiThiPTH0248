using System.ComponentModel.DataAnnotations;

namespace BaiThiPTH.Models;

public class StringProcess
{
    [Key]
    public int ID{ get; set; }
    public string Name{ get; set; }
    public string Address{ get; set; }
    public string Age { get; set; }
    public string PhoneNumber{ get; set; }

}