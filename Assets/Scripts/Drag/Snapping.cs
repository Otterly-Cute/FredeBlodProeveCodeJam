using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snapping : Drag
{
    public string snapPointName; // Name of the specific snap point

    private SnapManager snapManager;
    private Transform snapPoint;

    private void Start()
    {
        // Find the SnapManager in the scene
        snapManager = FindObjectOfType<SnapManager>();

        // Find the specific snap point by name
        snapPoint = snapManager.GetSnapPointByName(snapPointName);
    }

    new private void Update()
    {
        // Check if the object is close to the specific snap point
        if (snapManager != null && snapPoint != null)
        {
            Vector3 closestSnapPoint = snapPoint.position;
            if (Vector3.Distance(transform.position, closestSnapPoint) < snapManager.SnapDistance)
            {
                // Snap the object to the specific snap point
                transform.position = closestSnapPoint;
            }
        }
    }
}
