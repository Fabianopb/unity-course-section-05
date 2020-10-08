using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int blockCount = 0;

    SceneLoader sceneLoader;

    public void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void AddBlock()
    {
        blockCount++;
    }

    public void SubtractBlock()
    {
        blockCount--;
        if (blockCount <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
