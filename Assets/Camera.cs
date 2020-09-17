using UnityEngine;
using Vuforia;

public class Camera : MonoBehaviour
{
    public void Start()
    {
        CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
    }
}     
