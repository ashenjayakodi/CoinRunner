using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    public float fallLimitY = -10f;          // fall below this = respawn

    private Vector3 startPosition;
    private Rigidbody2D rb;
    private PlayerSFX sfx;                   // NEW

    void Start()
    {
        startPosition = transform.position;  // remember where we started
        rb = GetComponent<Rigidbody2D>();
        sfx = GetComponent<PlayerSFX>();     // NEW
    }

    void Update()
    {
        if (transform.position.y < fallLimitY)
        {
            Respawn();
        }
    }

    // TRIGGER = something we pass THROUGH (coins)
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            if (sfx != null) sfx.PlayCoin();   // NEW (step 5)
            GameManager.instance.AddCoin();
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Goal"))
        {
            if (sfx != null) sfx.PlayWin();    // NEW (step 7) - before LevelComplete
            GameManager.instance.LevelComplete();
        }
    }

    // COLLISION = something SOLID we bump into (spikes)
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Hazard"))
        {
            if (sfx != null) sfx.PlayHit();    // NEW (step 6)
            Respawn();
        }
    }

    void Respawn()
    {
        transform.position = startPosition;
        rb.linearVelocity = Vector2.zero;      // stop all movement
    }
}