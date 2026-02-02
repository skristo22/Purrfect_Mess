using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RusenjeObjekata : MonoBehaviour
{
    private bool alreadyCounted = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (alreadyCounted) return;

        if (collision.collider.CompareTag("Pod"))
        {
            alreadyCounted = true;

            BrojanjeObjekata.Instance.ObjectHitGround();
        }
    }
}