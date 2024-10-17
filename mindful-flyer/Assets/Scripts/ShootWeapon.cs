using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootWeapon : MonoBehaviour
{
    [SerializeField] InputActionReference shootAction;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] GameObject secondProjectilePrefab;

    [SerializeField] Transform aimTransform;
    [SerializeField] int energyDrain = 5;

    private PlayerEnergy playerEnergy = null;

    void Start()
    {
        if (shootAction)
        {
            shootAction.action.performed += Shoot;
        }

        playerEnergy = GetComponent<PlayerEnergy>();
    }

    private void Shoot(InputAction.CallbackContext context)
    {
        if (playerEnergy && playerEnergy.TryToUse(energyDrain))
        {
            Instantiate(projectilePrefab, transform.position + aimTransform.forward, aimTransform.rotation);
            Instantiate(secondProjectilePrefab, transform.position + aimTransform.forward * 0.5f, aimTransform.rotation);
        }
    }
}
