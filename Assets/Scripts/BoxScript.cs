using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour, IDrag
{
    private Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void onStartDrag()
    {
        rb.useGravity = false;
    }
    public void onEndDrag()
    {
        rb.useGravity = true;
        rb.velocity = Vector3.zero;
    }
}
