using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonsManager : MonoBehaviour
{
    public void RestartStage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SetTriggerFalse()
    {
        var droppable = FindObjectOfType<BlockObj>();
        if(droppable != null)
        {
            droppable.GetComponentInParent<Rigidbody>().isKinematic = false;
        }
    }
}
