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

    void Start()
    {
        if (shootAction)
        {
            shootAction.action.performed += Shoot;
        }
    }

    private void Shoot(InputAction.CallbackContext context)
    {
        Debug.Log("Shoot");
        Projectile projectile = Instantiate(projectilePrefab, transform.position + aimTransform.forward, aimTransform.rotation);
        // Debug.Log(aimTransform.forward);
        // projectile.Shoot(aimTransform.forward);
    }
}
