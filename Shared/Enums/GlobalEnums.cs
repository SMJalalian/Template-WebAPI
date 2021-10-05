using System.ComponentModel.DataAnnotations;

namespace MyProject.Shared.Enums
{
    public enum ResultStatus
    {
        [Display(Name = "Scuccessfull")]
        Scuccessfull = 1,
        [Display(Name = "Error")]
        Error = 2,
        [Display(Name = "Unknown")]
        Unknown = 3
    }

    public enum GenderType
    {
        [Display(Name = "Male")]
        Male = 0,
        [Display(Name = "Female")]
        Female = 1
    }
}
