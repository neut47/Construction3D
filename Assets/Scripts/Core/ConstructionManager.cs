using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionManager : MonoBehaviour
{
    [Header("Button")]
    public bool buttonPressed = false;

    [Header("Joystick")]
    private bool isJoystick = false;
    public Vector2 joystickValue;

    [Header("MousePos")]
    private Vector2 startPosition;
    private Vector2 deltaPosition;
    private Vector2 calculatedDeltaPosition;
    [SerializeField] private float treshold = 0.05f;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100f))
            {
                Debug.DrawRay(ray.origin, ray.direction);
                if (hit.collider.transform.TryGetComponent(out JoystickFind _))
                {
                    startPosition = Input.mousePosition;
                    isJoystick = true;
                }
                if (hit.collider.transform.TryGetComponent(out JoystickButton joystickButton))
                {
                    buttonPressed = !buttonPressed;
                    joystickButton.ButtonActivator(buttonPressed);
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isJoystick = false;
            joystickValue = Vector2.zero;
        }
        if(isJoystick)
        {
            MousePosCalculate();
        }
    }

    private void MousePosCalculate()
    {
        if (isJoystick)
        {
            deltaPosition = (Vector2)Input.mousePosition - startPosition;

            calculatedDeltaPosition = deltaPosition;

            calculatedDeltaPosition.x *= 0.1f * treshold;
            calculatedDeltaPosition.y *= 0.05f * treshold;

            calculatedDeltaPosition.x = Mathf.Clamp(calculatedDeltaPosition.x, -1, 1);
            calculatedDeltaPosition.y = Mathf.Clamp(calculatedDeltaPosition.y, -1, 1);

            joystickValue = calculatedDeltaPosition;
        }
    }
}
