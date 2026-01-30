using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float smooth = 6f;
    [SerializeField] Vector3 offset = new Vector3(0f, 0f, -10f);

    [Header("Follow axes")]
    [SerializeField] bool followY = false;

    void LateUpdate()
    {
        if (!target) return;

        float x = target.position.x;
        float y = followY ? target.position.y : transform.position.y; // drži Y stabilno

        Vector3 desired = new Vector3(x, y, 0f) + offset;
        transform.position = Vector3.Lerp(transform.position, desired, smooth * Time.deltaTime);
    }
}
