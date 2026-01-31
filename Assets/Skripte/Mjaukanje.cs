using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mjaukanje : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] meowClips;

    [Header("Timing")]
    [SerializeField] float minDelay = 1f;
    [SerializeField] float maxDelay = 10f;

    void Start()
    {
        StartCoroutine(MeowRoutine());
    }

    IEnumerator MeowRoutine()
    {
        while (true)
        {
            float waitTime = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(waitTime);

            if (meowClips.Length > 0)
            {
                AudioClip clip = meowClips[Random.Range(0, meowClips.Length)];
                audioSource.PlayOneShot(clip);
            }
        }
    }
}
