using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteUnnecessaryCorridors : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
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
