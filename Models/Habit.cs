using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HealthyHabits.Models
{
    public class Habit
    {
        [Key]
        public int HabitID { get; set; }
        [Required(ErrorMessage = "Required.")]
        public string HabitName { get; set; }
        public string HabitDesc { get; set; }
        public string Code { get; set; }
        [Required(ErrorMessage = "Required.")]
        public string Address { get; set; }
        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }
        [Display(Name = "Date Modified")]
        public DateTime? DateModified { get; set; }
        [Display(Name = "Item Type")]
        public Done Type { get; set; }
    }
    public enum Done
    {
        Ongoing = 1,
        Done = 2
    }
}
}
