using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContainerController : MonoBehaviour
{
    #region SINGLETON PATTERN
    private static ContainerController _instance;
    public static ContainerController Instance

    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<ContainerController>();
            }
            return _instance;
        }
    }
    #endregion;

    private List<Container> containers;
    private float counter = 0;
    [SerializeField] Text hitText;

    private void Update()
    {
        if(containers != null)
        {
            bool isAllContainersTriggered = true;
            for (int i = 0; i < containers.Count; i++)
            {
                if(!containers[i].isTriggered)
                {
                    isAllContainersTriggered = false;
                    counter = 0;
                    break;
                }
            }

            if(isAllContainersTriggered)
            {
                counter += Time.deltaTime;
                if(counter > 1f)
                {
                    hitText.text = "HIT";
                }
            }
        }
    }

    public void AddContainer(Container newContainer)
    {
        if(containers == null)
        {
            containers = new List<Container>();
        }
        containers.Add(newContainer);
    }

    public void RemoveContainer(Container newContainer)
    {
        containers.Remove(newContainer);
    }
}
