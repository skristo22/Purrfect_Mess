using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daljinski : MonoBehaviour
{
    public TVPaljenje tv;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Igrac"))
        {
            tv.UpaliTV();
        }
    }
}
