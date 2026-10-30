using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenumbraFollow : MonoBehaviour
{

    public Transform freind;
    private int movespeed;

    public int speed;
    public Rigidbody rb;
// Use this for initialization
    void Start()
    {
    speedup();
    }

// Update is called once per frame
    void Update()
    {

        transform.LookAt(freind);
        Vector3 eulerAngles = transform.rotation.eulerAngles;
        eulerAngles.x = 0;
        eulerAngles.z = 0;
        transform.rotation = Quaternion.Euler(eulerAngles);

        rb.AddRelativeForce(0, 0, movespeed);

    }

    public void OnTriggerStay(Collider other)
    {


    if (other.tag == "Player")
    {
        movespeed = 0;
    }

    }
    public void OnTriggerExit(Collider other)
    {
    speedup();
    }

    public void speedup()
    {
    movespeed = speed;
    }
}
