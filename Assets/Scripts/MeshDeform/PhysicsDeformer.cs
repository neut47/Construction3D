using UnityEngine;

public class PhysicsDeformer : MonoBehaviour
{
    public float collisionRadius = 0.1f;
    public DeformableMesh deformableMesh;

    void OnCollisionEnter(Collision collision)
    {
        foreach (var contact in collision.contacts)
        {
            deformableMesh.AddDepression(contact.point, collisionRadius);
        } 
    }
}