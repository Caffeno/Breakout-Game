using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CustomEventManager : MonoBehaviour
{

    public static CustomEventManager instance;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;    
    }

    public event Action<float> tileBreak;
    public void OnTileBreak(float progress)
    {
        if (tileBreak != null)
        {
            tileBreak(progress);
        }
    }
}
