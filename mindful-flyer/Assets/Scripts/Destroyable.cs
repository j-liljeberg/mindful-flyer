using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // TODO: Fracture object.
        Destroy(gameObject);
    }
}
