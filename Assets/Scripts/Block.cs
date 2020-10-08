using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    [SerializeField] AudioClip breakSound = null;

    Level level;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        level.AddBlock();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        FindObjectOfType<GameStatus>().IncreaseScore();
        Destroy();
    }

    private void Destroy()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        level.SubtractBlock();
        Destroy(gameObject);
    }
}
