using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DozerMovement : MonoBehaviour
{
    [SerializeField] private ConstructionManager constructionManager;
    [SerializeField] private Transform wrist;
    private float speed = 7;
    JoystickButton joystickButton;//Buttonun arda arda basýlmasýný engellemek için
    JoystickFind jFind;//joystick'in dozerin z ekseni yöneliminde hareketini engellemek için

    bool canMove = true;

    private void Start()
    {
        joystickButton = FindObjectOfType<JoystickButton>();
        jFind = FindObjectOfType<JoystickFind>();
    }
    private void Update()
    {
        if(constructionManager.joystickValue != Vector2.zero)
        {
            TheMover();
        }
    }

    public IEnumerator DozerZPos(bool isActivated)
    {
        if (isActivated)
        {
            speed = 3;
            jFind.GetComponent<Collider>().enabled = false;
            wrist.rotation = Quaternion.Euler(-180, 0, 0);
            joystickButton.GetComponent<Collider>().enabled = false;
            yield return StartCoroutine(MovePosition(transform, transform.position + (Vector3.forward * 2.5f), 1f));
            joystickButton.GetComponent<Collider>().enabled = true;
            jFind.GetComponent<Collider>().enabled = true;
        }
        if (!isActivated)
        {
            speed = 7;
            jFind.GetComponent<Collider>().enabled = false;
            joystickButton.GetComponent<Collider>().enabled = false;
            yield return StartCoroutine(MovePosition(transform, transform.position - (Vector3.forward * 2.5f), 1f));
            wrist.rotation = Quaternion.Euler(-135, 0, 0);
            joystickButton.GetComponent<Collider>().enabled = true;
            jFind.GetComponent<Collider>().enabled = true;
        }
    }

    private void TheMover()
    {
        Vector3 position = transform.position;

        position.x = Mathf.Clamp(position.x, -4.9f, +4.9f);
        position.y = Mathf.Clamp(position.y, -3.5f, 10.0f);

        position.x += constructionManager.joystickValue.x * speed * Time.deltaTime;
        position.y += constructionManager.joystickValue.y * speed * Time.deltaTime;

        transform.position = position;
    }

    public static IEnumerator MovePosition(Transform transform, Vector3 endPosition, float duration)
    {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0;
        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = endPosition;
    }
}
