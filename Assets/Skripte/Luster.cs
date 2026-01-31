using UnityEngine;

public class Luster : MonoBehaviour
{
    public int hitsToFall = 3;
    public float fallGravity = 3f;

    [Header("Debug")]
    public bool debugLogs = true;

    private int hitCount = 0;
    private bool hasFallen = false;

    private Rigidbody2D rb;
    private HingeJoint2D hinge;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        hinge = GetComponent<HingeJoint2D>();

        if (rb == null) Debug.LogError("Luster: Nema Rigidbody2D na istom objektu!");
        if (hinge == null) Debug.LogError("Luster: Nema HingeJoint2D na istom objektu!");

        // dok visi
        if (rb != null) rb.gravityScale = 1;
    }

    void Update()
    {
        // TEST: prisilni pad
        if (Input.GetKeyDown(KeyCode.F))
            Fall();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasFallen) return;

        if (debugLogs)
            Debug.Log($"Luster collision with: {collision.collider.name}, tag={collision.collider.tag}, relVel={collision.relativeVelocity}");

        if (!collision.collider.CompareTag("Igrac"))
            return;

        hitCount++;

        if (debugLogs)
            Debug.Log($"Luster HIT COUNT: {hitCount}/{hitsToFall}");

        if (hitCount >= hitsToFall)
            Fall();
    }

    void Fall()
    {
        if (hasFallen) return;
        hasFallen = true;

        if (debugLogs) Debug.Log("Luster FALL() CALLED");

        // makni joint
        if (hinge != null) Destroy(hinge);

        // osiguraj da fizički može pasti
        if (rb != null)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.simulated = true;
            rb.constraints = RigidbodyConstraints2D.None;
            rb.gravityScale = fallGravity;

            // probudi ga ako spava
            rb.WakeUp();
        }
    }
}
