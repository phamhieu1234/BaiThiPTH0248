using System.ComponentModel.DataAnnotations;

namespace BaiThiPTH.Models;

public class PTHCau3
{
    [Key]
    [Display(Name ="Mã Sinh Viên")]
    public int? Id{ get; set; }
    [Display(Name ="Tên Sinh Viên")]
    public string NameSV{ get; set; }
    [Display(Name ="Tuổi")]
    public string Age { get; set; }

}