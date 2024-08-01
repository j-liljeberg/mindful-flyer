using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] float speed = 1;

    void Update()
    {
        transform.position = transform.position + Vector3.forward * speed * Time.deltaTime;
    }
}
