using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BoxColliderToggle : MonoBehaviour
{
    public UnityEvent onEnableColliderEvent;
    private BoxCollider boxCollider;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();

        // Register the EnableCollider method to the onEnableColliderEvent
        onEnableColliderEvent.AddListener(EnableCollider);
    }

    private void EnableCollider()
    {
        if (boxCollider != null)
        {
            boxCollider.enabled = true;
        }
    } 
        
    
}

