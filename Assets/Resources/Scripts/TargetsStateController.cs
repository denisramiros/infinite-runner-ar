using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetsStateController : MonoBehaviour
{
    private bool isPlayerFound;
    private bool isRoadFound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnPlayerFound()
    {
        isPlayerFound = true;
    }

    public void OnPlayerLost()
    {
        isPlayerFound = false;
    }

    public void OnRoadFound()
    {
        isRoadFound = true;
    }

    public void OnRoadLost()
    {
        isRoadFound = false;
    }

    public bool TargetsFound()
    {
        return isPlayerFound && isRoadFound;
    }
}
