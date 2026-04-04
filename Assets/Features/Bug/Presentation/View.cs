using UnityEngine;
using UnityEngine.UI;

namespace Bug.Presentation
{
    public class View : MonoBehaviour, IView
    {
        [SerializeField] private Text _workersDeathsText;
        [SerializeField] private Text _predatorsDeathsText;

        public void UpdateWorkersDeaths(int count)
        {
            _workersDeathsText.text = $"Workers Deaths: {count}";
        }

        public void UpdatePredatorsDeaths(int count)
        {
            _predatorsDeathsText.text = $"Predators Deaths: {count}";
        }
    }
}