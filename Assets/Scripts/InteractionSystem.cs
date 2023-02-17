using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    //detection point
    public Transform detectionPoint;
    //detection radius
    private const float detectionRadius = 0.2f;
    //detection layer
    public LayerMask detectionLayer;

    // Update is called once per frame
    void Update()
    {
        if (DetectObject())
        {
            if (InteractInput())
            {
                Debug.Log("Interact");
            }
        }
    }

    bool InteractInput()
    {
        return Input.GetKeyDown(KeyCode.E);
    }

    bool DetectObject()
    {
        return Physics2D.OverlapCircle(detectionPoint.position, detectionRadius, detectionLayer);
    }

    // private void OnDrawGizmoSelected()
    // {

    // }
}
