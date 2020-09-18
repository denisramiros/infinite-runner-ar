using UnityEngine;

namespace Resources.Scripts
{
    public class TargetsStateController : MonoBehaviour
    {
        private bool _isPlayerFound;
        private bool _isRoadFound;

        public void OnPlayerFound()
        {
            _isPlayerFound = true;
        }

        public void OnPlayerLost()
        {
            _isPlayerFound = false;
        }

        public void OnRoadFound()
        {
            _isRoadFound = true;
        }

        public void OnRoadLost()
        {
            _isRoadFound = false;
        }

        public bool TargetsFound()
        {
            return _isPlayerFound && _isRoadFound;
        }
    }
}
