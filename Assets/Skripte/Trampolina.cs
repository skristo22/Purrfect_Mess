using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(AudioSource))]
public class Trampolina : MonoBehaviour
{
    [Header("Bounce settings")]
    public float bounceForce = 18f;
    public float cooldown = 0.2f;

    [Header("Squash settings")]
    public float squashX = 1.1f;
    public float squashY = 0.85f;
    public float squashDuration = 0.1f;

    private bool canBounce = true;
    private Vector3 originalScale;
    private AudioSource audioSource;

    void Start()
    {
        originalScale = transform.localScale;
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!canBounce) return;

        if (other.CompareTag("Igrac"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb == null) return;

            // mora padati odozgo
            if (rb.velocity.y <= 0f)
            {
                StartCoroutine(Bounce(rb));
            }
        }
    }

    private IEnumerator Bounce(Rigidbody2D rb)
    {
        canBounce = false;

        // reset Y brzine
        rb.velocity = new Vector2(rb.velocity.x, 0f);

        // SQUASH efekt
        transform.localScale = new Vector3(
            originalScale.x * squashX,
            originalScale.y * squashY,
            originalScale.z
        );

        // zvuk
        if (audioSource != null)
            audioSource.Play();

        // skok
        rb.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);

        yield return new WaitForSeconds(squashDuration);

        // vrati scale
        transform.localScale = originalScale;

        yield return new WaitForSeconds(cooldown);
        canBounce = true;
    }
}
