using System.ComponentModel.DataAnnotations;


namespace State_Managment.Enums
{
    public enum FlashMessageTypes
    {
        [Display(Name = "danger")]
        Error = 1,

        [Display(Name = "success")]
        Success = 2,

        [Display(Name = "warning")]
        Warning = 3
    }
}
