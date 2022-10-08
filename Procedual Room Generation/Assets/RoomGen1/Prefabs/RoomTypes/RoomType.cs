using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Room Type", menuName = "Room Type")]
public class RoomType : ScriptableObject
{
 
    [SerializeField] List<int> enterances = new List<int>();


    public List<int> Enterances
    {
        get { return enterances; }
    }
}
