using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour, IDrag
{
    private Rigidbody rb;
    private void Awake()
    {
        //box (or any object we want to be draggable) has rigid body
        rb = GetComponent<Rigidbody>();
    }

    public void onStartDrag()
    {
        //set gravity to false
        rb.useGravity = false;
    }
    public void onEndDrag()
    {
        //when dragging ends, set gravity to true
        rb.useGravity = true;
        //velocity of object is now zero as it does not move
        rb.velocity = Vector3.zero;
    }
}
