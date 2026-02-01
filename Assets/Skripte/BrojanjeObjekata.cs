using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BrojanjeObjekata : MonoBehaviour
{
    public static BrojanjeObjekata Instance;

    public int objectsToDestroy = 5;
    public int destroyedCount = 0;

    public TextMeshProUGUI counterText;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        UpdateUI();
    }

    public void ObjectHitGround()
    {
        destroyedCount++;
        UpdateUI();

        if (destroyedCount >= objectsToDestroy)
        {
            WinGame();
        }
    }

    void UpdateUI()
    {
        if (counterText != null)
            counterText.text = $"Sruseno: {destroyedCount} / {objectsToDestroy}";
    }

    void WinGame()
    {
        Debug.Log("🎉 POBJEDA! Sve si srušila!");
        // ovdje kasnije ide end screen
    }
}
