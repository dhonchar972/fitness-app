using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessApp.BL.Model
{
    [Serializable]
    public class Exercise
    {
        public Exercise(TimeOnly start, TimeOnly finish, Activity activity, User user)
        {
            //Control
            Start = start;
            Finish = finish;
            Activity = activity;
            User = user;
        }
        public Exercise() { }
        [Key]
        [Column(Order = 1)]
        public int Id { get; set; }
        public TimeOnly Start { get; set; }
        public TimeOnly Finish { get; set; }
        public int ActivityId { get; set; }
        public virtual Activity Activity { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
