using FitnessApp.BL.Model;
using System.Collections.Generic;
using System.Linq;

namespace FitnessApp.BL.Controller
{
    public class DatabaseDataSaver : IDataSaver
    {
        public List<T> Load<T>() where T : class
        {
            using (var db = new ApplicationContext())
            {
                var result = db.Set<T>().Where(k => true).ToList();
                return result;
            }
        }

        public void Save<T>(List<T> item) where T : class
        {
            using (var db = new ApplicationContext())
            {
                #region if version.
                //var type = item.GetType();
                //if (type == typeof(Activity))
                //{
                //    db.Activitys.Add(item as Activity);
                //}
                //else if (type == typeof(Eating))
                //{
                //    db.Eatings.Add(item as Eating);
                //}
                //else if (type == typeof(Exercise))
                //{
                //    db.Exercises.Add(item as Exercise);
                //}
                //else if (type == typeof(Food))
                //{
                //    db.Foods.Add(item as Food);
                //}
                //else if (type == typeof(Gender))
                //{
                //    db.Genders.Add(item as Gender);
                //}
                //else if (type == typeof(User))
                //{
                //    db.Users.Add(item as User);
                //}
                #endregion
                #region switch version.
                //switch (item)
                //{
                //    case Activity _ when item.GetType() == typeof(Activity):
                //        db.Activitys.Add(item as Activity);
                //        break;
                //    case Eating _ when item.GetType() == typeof(Eating):
                //        db.Eatings.Add(item as Eating);
                //        break;
                //    case Exercise _ when item.GetType() == typeof(Exercise):
                //        db.Exercises.Add(item as Exercise);
                //        break;
                //    case Food _ when item.GetType() == typeof(Food):
                //        db.Foods.Add(item as Food);
                //        break;
                //    case Gender _ when item.GetType() == typeof(Gender):
                //        db.Genders.Add(item as Gender);
                //        break;
                //    case User _ when item.GetType() == typeof(User):
                //        db.Users.Add(item as User);
                //        break;
                //}
                #endregion
                db.Set<T>().AddRange(item);
                db.SaveChanges();
            }
        }
    }
}
