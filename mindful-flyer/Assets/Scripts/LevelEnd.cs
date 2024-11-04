using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    private Transform player;

    private bool isActivated = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    void Update()
    {
        if (player != null && !isActivated)
        {
            if (player.position.z >= transform.position.z)
            {
                isActivated = true;
                GameEvents.Instance.LevelEnd();
            }
        }
    }
}
