using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // config
    [SerializeField] AudioClip breakSound = null;
    [SerializeField] GameObject blockSparklesVFX = null;
    [SerializeField] Sprite[] damageLevelSprites = null;

    // references
    Level level;

    // state
    [SerializeField] int timesHit = 0; // TODO: serialized for debug purposes

    private void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.AddBlock();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        int maxHits = damageLevelSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextDamageSprite();
        }
    }

    private void ShowNextDamageSprite()
    {
        int spriteIndex = timesHit - 1;
        if (damageLevelSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = damageLevelSprites[spriteIndex];
        } else
        {
            Debug.LogError("Block sprite is missing from array - " + gameObject.name);
        }
    }

    private void DestroyBlock()
    {
        FindObjectOfType<GameSession>().IncreaseScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        level.SubtractBlock();
        TriggerSparklesVFX();
        Destroy(gameObject);
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
