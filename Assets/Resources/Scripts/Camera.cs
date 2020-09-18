using UnityEngine;
using Vuforia;

namespace Resources.Scripts
{
    public class Camera : MonoBehaviour
    {
        public void Start()
        {
            CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
        }
    }
}     
