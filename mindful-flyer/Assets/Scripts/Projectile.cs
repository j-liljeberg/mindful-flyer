using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 10;

    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = rb.transform.forward * speed;
    }

    void Update()
    {
        Debug.Log(rb.velocity);
    }

    // public void Shoot(Vector3 direction)
    // {
    //     rb.isKinematic = false;
    //     rb.AddForce(direction * speed * 1000);
    //     print(rb.isKinematic);
    // }
}
