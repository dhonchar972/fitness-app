using FitnessApp.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FitnessApp.BL.Controller
{
    public class ExerciseController : ControllerBase
    {
        private const string EXERCISES_FILE_NAME = "D:\\FitnessApp\\FitnOne.BL\\Sources\\exercise.dat";
        private const string ACTIVITIES_FILE_NAME = "D:\\FitnessApp\\FitnOne.BL\\Sources\\activity.dat";
        private readonly User user;
        public List<Exercise> Exercises { get; }
        public List<Activity> Activities { get; }

        public ExerciseController(User user)
        {
            this.user = user ?? throw new ArgumentNullException(nameof(user));
            Exercises = GetAllExercises();
            Activities = GetAllActivities();
        }

        private List<Activity> GetAllActivities()
        {
            return base.Load<Activity>() ?? new List<Activity>();
        }

        public void Add(Activity activity, DateTime start, DateTime finish)
        {
            var activ = Activities.SingleOrDefault(a => a.Name == activity.Name);
            if (activ == null)
            {
                Activities.Add(activity);
                var exercise = new Exercise(start, finish, activity, user);
                Exercises.Add(exercise);
            }
            else
            {
                var exercise = new Exercise(start, finish, activity, user);
                Exercises.Add(exercise);

            }
            Save();
        }
        private List<Exercise> GetAllExercises()
        {
            return base.Load<Exercise>() ?? new List<Exercise>();
        }
        private void Save()
        {
            base.Save(Exercises);
            base.Save(Activities);
        }
    }
}
