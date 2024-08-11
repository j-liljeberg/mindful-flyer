using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootWeapon : MonoBehaviour
{
    [SerializeField] InputActionReference shootAction;
    [SerializeField] Projectile projectilePrefab;
    [SerializeField] Transform aimTransform;
    [SerializeField] float energyDrain = 5f;

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
        }
    }
}
