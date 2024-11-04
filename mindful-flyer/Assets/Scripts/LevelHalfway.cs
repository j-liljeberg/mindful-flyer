using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Halfway : MonoBehaviour
{
    private Transform player;

    private bool isActivated = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && !isActivated)
        {
            if (player.position.z >= transform.position.z)
            {
                isActivated = true;
                GameEvents.Instance.LevelHalfway();
            }
        }
    }
}
