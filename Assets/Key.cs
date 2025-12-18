using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    //show key when lock combination is correctly inputted
    public void showKey()
    {
        gameObject.SetActive(true);
    }
}
