using UnityEngine;

namespace Bug.Presentation
{
    public interface IView
    {
        void UpdateWorkersDeaths(int count);
        void UpdatePredatorsDeaths(int count);
    }
}