using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapEvent : Snapping
{
    private Eventmanager eventmanager;
    private bool hasTriggeredEvent = false;

    private void Awake()
    {
        eventmanager = FindObjectOfType<Eventmanager>();
        if (eventmanager == null)
        {
            Debug.LogError("No Eventmanager found in the scene");
        }
    }

    new void Update()
    {
        base.Update();
        if (isSnapped && !hasTriggeredEvent)
        {
            eventmanager.TriggerEvent();
            hasTriggeredEvent = true;
        }
    }
}
