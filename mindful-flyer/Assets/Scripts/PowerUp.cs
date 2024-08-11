using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] float availablePower = 30f;
    [SerializeField] float powerRate = 10f;
    [SerializeField] float activationTime = 1f;

    public float ActivationTime { get { return activationTime; } }

    public float GetPowerUp()
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
