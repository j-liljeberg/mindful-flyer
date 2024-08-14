using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObject : MonoBehaviour
{
    [SerializeField] int damage;

    public int GetDamage()
    {
        return damage;
    }
}
