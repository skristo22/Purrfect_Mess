using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] Transform target;

    [Header("Follow settings")]
    [SerializeField] float smooth = 6f;
    [SerializeField] Vector3 offset = new Vector3(0f, 0f, -10f);
    [SerializeField] bool followY = false;

    [Header("Camera bounds")]
    [SerializeField] float minX;
    [SerializeField] float maxX;
    [SerializeField] float minY;
    [SerializeField] float maxY;

    void LateUpdate()
    {
        if (!target) return;

        // željena pozicija
        float x = target.position.x;
        float y = followY ? target.position.y : transform.position.y;

        // clamp granice
        x = Mathf.Clamp(x, minX, maxX);
        y = Mathf.Clamp(y, minY, maxY);

        Vector3 desired = new Vector3(x, y, 0f) + offset;

        // smooth follow
        transform.position = Vector3.Lerp(
            transform.position,
            desired,
            smooth * Time.deltaTime
        );
    }
}
