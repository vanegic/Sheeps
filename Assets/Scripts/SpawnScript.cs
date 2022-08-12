using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject sheep;
    public MeshCollider floor;

    private float x, z;
    private Vector3 spawnPosition;
    private Collider[] colliders;

    void Start()
    {
        SpawnSheeps();
    }

    private void SpawnSheeps()
    {
        int sheepCount = 0;
        while (sheepCount < 21)
        {
            spawnPosition = CreatePosition();
            if (CheckPosition(spawnPosition))
            {
                GameObject newSheep = Instantiate(sheep, spawnPosition, Quaternion.Euler(0, Random.Range(0, 360), 0));
                newSheep.name = "Sheep " + ++sheepCount;
            }
        }
    }

    private Vector3 CreatePosition()
    {
        x = Random.Range(-floor.bounds.extents.x + 0.5f, floor.bounds.extents.x - 0.5f);
        z = Random.Range(-floor.bounds.extents.z + 0.5f, floor.bounds.extents.z - 0.5f);
        return new Vector3(x, 0.3f, z);
    }

    private bool CheckPosition(Vector3 position)
    {
        colliders = Physics.OverlapBox(position, new Vector3(0.25f, 0.25f, 0.25f));
        if (colliders.Length > 0)
        {
            return false;
        } else
        {
            return true;
        }
    }
}
