using System.ComponentModel.DataAnnotations;

namespace Administrator.Contract
{
    
    #region ViewModel para catalogos en general

    public class ViewModelCatlogs
    {
        [Display(Name = "id")]
        public int Value { get; set; }

        [Display(Name = "Valor")]
        public string Text { get; set; }
    }

    #endregion
}
