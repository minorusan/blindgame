using System.Collections.Generic;


namespace Core
{
    public class UpdateController
    {
        private const int AVARAGE_UPDATERS_COUNT = 1000;
        private List<IUpdatable> _updateQueue = new List<IUpdatable>(AVARAGE_UPDATERS_COUNT);

        public void AddUpdatable(IUpdatable newUpdatable)
        {
            _updateQueue.Add(newUpdatable);
        }

        public void Update()
        {
            var count = _updateQueue.Count;
            for (int i = 0; i < count; i++)
            {
                _updateQueue[i].PerformUpdate();
            }
        }

        public void Dispose()
        {
            foreach (var item in _updateQueue)
            {
                item.Dispose();
            }
            _updateQueue.Clear();
        }
    }
}