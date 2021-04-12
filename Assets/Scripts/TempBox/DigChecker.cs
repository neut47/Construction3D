using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Apk halinde meshin 2d arayüzünden ötürü, kazýlmayan bölge içerisine düþen nesne buga girmektedir
//TempBox ile küçük çapta bu sorunu engellemeye çalýþtým.
//Proje, Editör içerisinde TempBox olmadan da düzgün çalýþmaktadýr.
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
