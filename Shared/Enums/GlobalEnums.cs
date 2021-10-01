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
}
