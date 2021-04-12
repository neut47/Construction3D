using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(GeneratePlaneMesh))]
public class DeformableMesh : MonoBehaviour
{
    public float maximumDepression;
    private List<Vector3> originalVertices;
    private List<Vector3> modifiedVertices;

    private GeneratePlaneMesh plane;
    private MeshCollider meshCol;

    private void Start()
    {
        meshCol = GetComponent<MeshCollider>();
        plane = GetComponent<GeneratePlaneMesh>();
        MeshRegenerated();
        meshCol.sharedMesh = plane.mesh;
    }

    public void MeshRegenerated()
    {
        plane.mesh.MarkDynamic();
        originalVertices = plane.mesh.vertices.ToList();
        modifiedVertices = plane.mesh.vertices.ToList();
        //Debug.Log("Mesh Regenerated");
    }

    public void AddDepression(Vector3 depressionPoint, float radius)
    {
        var worldPos4 = this.transform.worldToLocalMatrix * depressionPoint;
        var worldPos = new Vector3(worldPos4.x, worldPos4.y, worldPos4.z);
        for (int i = 0; i < modifiedVertices.Count; ++i)
        {
            var distance = (worldPos - (modifiedVertices[i] + Vector3.down * maximumDepression)).magnitude;
            if (distance < radius)
            {
                var newVert = originalVertices[i] + Vector3.down * maximumDepression;
                modifiedVertices.RemoveAt(i);
                modifiedVertices.Insert(i, newVert);
            }
        }

        plane.mesh.SetVertices(modifiedVertices);
        MeshRegenerated();
        meshCol.sharedMesh = plane.mesh;
    }
}