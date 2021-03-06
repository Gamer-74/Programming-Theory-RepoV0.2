using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 25;
    private float lowerBound = 5;
    private float sideBound = 28;

    void Update()
    {
        DestroyObjects();
    }

    private void DestroyObjects()
    {
        if(transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        if(transform.position.z < -lowerBound)
        {
            Destroy(gameObject);
        }
        if(transform.position.x < -sideBound)
        {
            Destroy(gameObject);
        }
        if(transform.position.x > sideBound)
        {
            Destroy(gameObject);
        }
    }
}
