using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentObjects : MonoBehaviour
{
    public static PersistentObjects Instance;
    public bool[] milkActive = new bool[28];


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        for (int i = 0; i < milkActive.Length; i++)
    {
        milkActive[i] = true;
    }
    }
}
