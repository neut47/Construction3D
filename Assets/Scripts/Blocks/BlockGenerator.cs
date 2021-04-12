using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGenerator : MonoBehaviour
{
    [Tooltip("Scriptable Blocks")]
    [SerializeField] Block[] targetBlocks;
    [Tooltip("mainObj, TargetObj  unpacked Prefab")]
    [SerializeField] CreateObject[] objectCreators;
    public void GenerateRandomBlocks()
    {
        Block targetBlock = targetBlocks[Random.Range(0, targetBlocks.Length)];
        for (int i = 0; i < objectCreators.Length; i++)
        {
            objectCreators[i].TryRemoveBlocks();
            objectCreators[i].GenerateBlocks(targetBlock);
        }
    }
}
