using System.Collections.Generic;

namespace FitnessApp.BL.Controller
{
    public abstract class ControllerBase
    {
        private readonly IDataSaver _dataSaver = new DatabaseDataSaver();
        protected void Save<T>(List<T> item) where T : class
        {
            _dataSaver.Save(item);
        }
        protected List<T> Load<T>() where T : class
        {
            return _dataSaver.Load<T>();
        }
    }
}
