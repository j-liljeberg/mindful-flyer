using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ActivatePhysics : MonoBehaviour
{
    [SerializeField] Rigidbody rb;

    private Transform player;

    private bool isActivated = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    void Update()
    {
        if (player != null && rb != null && !isActivated)
        {
            if (player.position.z >= transform.position.z)
            {
                rb.isKinematic = false;
                isActivated = true;
            }
        }
    }

}
