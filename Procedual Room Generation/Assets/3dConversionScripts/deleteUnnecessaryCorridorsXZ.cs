using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteUnnecessaryCorridorsXZ : MonoBehaviour
{
    void OnTriggerEnter(Collider collision)
    {
            if (collision.CompareTag("Corridor"))
            {
                if (CompareTag("ExitWall"))
                {
                    Destroy(gameObject);
                }
                else
                {

                    Destroy(collision.gameObject);
                }
                
            }
        
        
    }
}
