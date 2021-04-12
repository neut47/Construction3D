using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Block", menuName = "ScriptableObjects/NewBlock", order = 0)]
public class Block : ScriptableObject
{
    public List<Vector3> blockNormalizedPositionList;

}
