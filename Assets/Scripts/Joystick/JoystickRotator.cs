using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickRotator : MonoBehaviour
{
    [SerializeField] private ConstructionManager constructionManager;
    [SerializeField] private float speed = 30;

    private float rotationX;
    private float rotationZ;

    private void Update()
    {
        if(constructionManager.joystickValue != Vector2.zero)
        {
            rotationX = constructionManager.joystickValue.y * speed;
            rotationX = Mathf.Clamp(rotationX, -30, 30);
            rotationZ = constructionManager.joystickValue.x * speed;
            rotationZ = Mathf.Clamp(rotationZ, -30, 30);
            transform.rotation = Quaternion.Euler(rotationX, 0, -rotationZ);
        }
        else
        {
            transform.rotation = Quaternion.identity;
        }
    }
}
