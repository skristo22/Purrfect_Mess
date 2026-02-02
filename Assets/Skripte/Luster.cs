using UnityEngine;

public class Luster : MonoBehaviour
{
    public int hitsToFall = 3;
    public float fallGravity = 3f;

    private int hitCount = 0;
    private bool hasFallen = false;

    private Rigidbody2D rb;
    private HingeJoint2D hinge;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        hinge = GetComponent<HingeJoint2D>();

        if (rb != null) rb.gravityScale = 1;
    }

    void Update()
    {
     
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasFallen) return;

        if (!collision.collider.CompareTag("Igrac"))
            return;
        hitCount++;

        if (hitCount >= hitsToFall)
            Fall();
    }

    void Fall()
    {
        if (hasFallen) return;
        hasFallen = true;


        if (hinge != null) Destroy(hinge);

        if (rb != null)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.simulated = true;
            rb.constraints = RigidbodyConstraints2D.None;
            rb.gravityScale = fallGravity;

            rb.WakeUp();
        }
    }
}
