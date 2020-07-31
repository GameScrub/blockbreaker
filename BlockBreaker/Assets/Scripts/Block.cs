using UnityEngine;

public class Block : MonoBehaviour
{

    // Configuration Parameters
    [SerializeField] private AudioClip breakSound = null;
    [SerializeField] private GameObject blockSparklesVFX = null;
    [SerializeField] private Sprite[] hitSprites = null;

    // Cached reference
    private Level level;
    private GameState state;

    // State variables (Serialized for debugging)
    [SerializeField] private int timesHits;


    private void Start()
    {
        CountBreakableBlocks();

        state = FindObjectOfType<GameState>();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();

        if (gameObject.tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);

        if (gameObject.tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHits++;
        int maxHits = hitSprites.Length + 1;
        if (timesHits >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        var spriteIndex = timesHits - 1;
        if (hitSprites[spriteIndex] != null)
        {
            var sprite = hitSprites[spriteIndex];
            var spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = sprite;
        }
        else
        {
            Debug.LogError("Block sprite is missing from array " + gameObject.name);
        }
    }

    private void DestroyBlock()
    {
        TriggerFX();

        state.AddToScore();

        level.BlockDestroyed();

        Destroy(gameObject);
    }

    private void TriggerFX()
    {
        
        GameObject sparkles = Object.Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
