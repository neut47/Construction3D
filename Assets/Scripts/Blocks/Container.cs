using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    public bool isTriggered;
    void Start()
    {
        ContainerController.Instance.AddContainer(this);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.GetComponent<BlockObj>())
        {
            isTriggered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<BlockObj>())
        {
            isTriggered = false;
        }
    }

    private void OnDestroy()
    {
        ContainerController.Instance.RemoveContainer(this);
    }
}
