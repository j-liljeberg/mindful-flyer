using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] int availablePower = 30;
    [SerializeField] int powerRate = 10;
    [SerializeField] float activationTime = 1f;

    public float ActivationTime { get { return activationTime; } }

    public int GetPowerUp()
    {
        if (availablePower >= powerRate)
        {
            availablePower -= powerRate;
            return powerRate;
        }
        else
        {
            Destroy(this.gameObject);
        }
        return 0;
    }
}
