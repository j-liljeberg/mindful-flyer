using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(PlayerEnergy))]
public class PlayerDamage : MonoBehaviour
{
    PlayerEnergy playerEnergy;

    void Start()
    {
        playerEnergy = GetComponent<PlayerEnergy>();
    }

    private void OnTriggerEnter(Collider other)
    {
        DamageObject damageObject;
        if (other.TryGetComponent<DamageObject>(out damageObject))
        {
            playerEnergy.Decrease(damageObject.GetDamage());
        }
    }
}
