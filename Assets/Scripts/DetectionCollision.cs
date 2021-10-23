using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
       Destroy(gameObject);
       PlayerController player = GameObject.Find("Player").GetComponent<PlayerController>();
        if(other.gameObject)
        {
            Destroy(gameObject); 
        }
    }
}
