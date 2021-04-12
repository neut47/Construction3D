using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickButton : MonoBehaviour
{
    Renderer rendColor;
    bool isActive;
    private void Start()
    {
        rendColor = GetComponent<Renderer>();
    }

    public void ButtonActivator(bool isActivated)
    {
        if (isActivated)
        {
            transform.position += new Vector3(0, -0.2f, 0);
            rendColor.material.color = Color.green;
            isActive = isActivated;
            DozerDigging();
        }
        if (!isActivated)
        {
            transform.position += new Vector3(0, 0.2f, 0);
            rendColor.material.color = Color.red;
            isActive = isActivated;
            DozerDigging();
        }
    }

    private void DozerDigging()
    {
        DozerMovement dozerMov = FindObjectOfType<DozerMovement>();
        StartCoroutine(dozerMov.DozerZPos(isActive));
    }
}
