using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Restart : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameEvents.Instance.Restart();
    }
}