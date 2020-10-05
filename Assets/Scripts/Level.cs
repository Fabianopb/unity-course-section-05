using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int blockCount = 0;

    public void AddBlock()
    {
        blockCount++;
    }

    public void SubtractBlock()
    {
        blockCount--;
    }
}
