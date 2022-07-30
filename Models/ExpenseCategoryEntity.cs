using System.ComponentModel;

using System.ComponentModel.DataAnnotations;

namespace ExpenseManagement.Models
{
    public class ExpenseCategoryEntity
    {

        [Key]
        public int ExpenseCategoryId { get; set; }
        [Required]
        public string ExpenseCategoryName { get; set; }
    }

}
