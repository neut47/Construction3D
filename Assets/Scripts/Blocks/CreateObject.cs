using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObject : MonoBehaviour
{
    public GameObject prefab;

    private void CreateCube(Vector3 pivot, Vector3 offSet)
    {
        GameObject go = Instantiate(prefab);
        go.transform.position = pivot + offSet;
        go.transform.SetParent(transform);
    }

    public void GenerateBlocks(Block block)
    {
        for(int i = 0; i < block.blockNormalizedPositionList.Count; i++)
        {
            CreateCube(transform.position, block.blockNormalizedPositionList[i]);
        }
    }

    public void TryRemoveBlocks()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }


}
