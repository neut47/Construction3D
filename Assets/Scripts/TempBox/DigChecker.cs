using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Apk halinde meshin 2d aray�z�nden �t�r�, kaz�lmayan b�lge i�erisine d��en nesne buga girmektedir
//TempBox ile k���k �apta bu sorunu engellemeye �al��t�m.
//Proje, Edit�r i�erisinde TempBox olmadan da d�zg�n �al��maktad�r.
public class DigChecker : MonoBehaviour
{
    bool shouldTrigger = false;
    private void Update()
    {
        if (shouldTrigger == false)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.back, out hit, 1f))
            {
                if (hit.collider.transform.GetComponentInChildren<BoxCollider>())
                {
                    shouldTrigger = true;
                    gameObject.SetActive(false);
                }
            }
        }

    }
}
