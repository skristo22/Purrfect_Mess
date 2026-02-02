using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVPaljenje : MonoBehaviour
{
    public GameObject tvOffObj;
    public GameObject tvOnObj;

    void Start()
    {
        tvOffObj.SetActive(true);
        tvOnObj.SetActive(false);
    }

    public void UpaliTV()
    {
        tvOffObj.SetActive(false);
        tvOnObj.SetActive(true);
    }
}
