using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
