using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapEvent : Snapping
{
    private ITriggerable triggerable;
    private bool hasTriggeredEvent = false;

    private void Awake()
    {
        triggerable = GetComponent<ITriggerable>();
        if (triggerable == null) {
            Debug.LogError("No Eventmanager found in the scene");
        }
    }

    new void Update()
    {
        base.Update();
        if (isSnapped && !hasTriggeredEvent)
        {
            triggerable.TriggerEvent(this.gameObject);
            hasTriggeredEvent = true;
        }
    }
}
