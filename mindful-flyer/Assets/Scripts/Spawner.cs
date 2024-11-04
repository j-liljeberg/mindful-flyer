using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] bool active;
    [SerializeField] GameObject prefab;
    [SerializeField] float spawnInterval;

    float spawnTimer;

    void Start()
    {
        spawnTimer = spawnInterval;
        if (active)
        {
            SpawnPrefab();
        }
    }

    void Update()
    {
        if (active)
        {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer < 0)
            {
                spawnTimer = spawnInterval;
                SpawnPrefab();
            }
        }
    }

    private void SpawnPrefab()
    {
        GameObject gameObject = Instantiate(prefab, transform.position, transform.rotation);
        gameObject.transform.parent = transform;

        Rigidbody rb;
        if (gameObject.TryGetComponent<Rigidbody>(out rb))
        {
            rb.isKinematic = false;
            rb.useGravity = true;
        }
    }
}
