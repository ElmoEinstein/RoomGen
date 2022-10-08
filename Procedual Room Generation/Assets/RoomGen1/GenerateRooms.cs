using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRooms : MonoBehaviour
{
    

    List<Vector2> roomPos = new List<Vector2>();
    


    [SerializeField] GameObject startingIns;
    GameObject roomOnIns;
    GameObject roomOn;

    Vector2 roomPosOn;
    GameObject nextRoom;
    [SerializeField] RoomTemplates roomTemplates;

    [SerializeField] Vector2 startingPoint;
    [SerializeField] float width;
    [SerializeField] float height;

    void Start()
    {
        roomPosOn = new Vector2(0,0);
        roomOn = startingIns;
        roomOnIns = Instantiate(startingIns, startingPoint, Quaternion.identity);
        roomPos.Add(roomPosOn);


 

        Debug.Log(roomPos[0]);
    }

    void Update()
    {
        pickRandomRoom();
    }

    void pickRandomRoom()
    {


        GameObject _potentialNextRoom = null;
        Vector2 _potentialRoomPos = new Vector2(0,0);

        List<int> _randomEnteranceRange = new List<int> { 0,1,2,3};
    

        int randomEnterance = _randomEnteranceRange[Random.Range(0,_randomEnteranceRange.Count)];
        Debug.Log(randomEnterance);
        while (_potentialNextRoom == null)
        {
            if (randomEnterance == 0)
            {
                if (roomTemplates.topRooms.Contains(roomOn))
                {
                    _potentialRoomPos = new Vector2(roomPosOn.x,roomPosOn.y + 1);
                    if (!roomPos.Contains(_potentialRoomPos))
                    {
                        _potentialNextRoom = roomTemplates.bottomRooms[Random.Range(0, roomTemplates.bottomRooms.Count)];
                    }
                    else
                    {
                        
                        randomEnterance = _randomEnteranceRange[Random.Range(0, _randomEnteranceRange.Count)];

                        _randomEnteranceRange.Remove(0);
                    }




                }
                else
                {
                    randomEnterance = _randomEnteranceRange[Random.Range(0, _randomEnteranceRange.Count)];
                    _randomEnteranceRange.Remove(0);
                }

            }

            if (randomEnterance == 1)
            {
                if (roomTemplates.rightRooms.Contains(roomOn))
                {
                    _potentialRoomPos = new Vector2(roomPosOn.x + 1, roomPosOn.y );
                    if (!roomPos.Contains(_potentialRoomPos))
                    {
                        _potentialNextRoom = roomTemplates.leftRooms[Random.Range(0, roomTemplates.leftRooms.Count)];

                    }
                    else
                    {
                        randomEnterance = _randomEnteranceRange[Random.Range(0, _randomEnteranceRange.Count)];
                        _randomEnteranceRange.Remove(1);
                    }


                }
                else
                {
                    randomEnterance = _randomEnteranceRange[Random.Range(0, _randomEnteranceRange.Count)];
                    _randomEnteranceRange.Remove(1);
                }
            }

            if (randomEnterance == 2)
            {
                if (roomTemplates.bottomRooms.Contains(roomOn))
                {
                   _potentialRoomPos = new Vector2(roomPosOn.x, roomPosOn.y - 1);
                    if (!roomPos.Contains(_potentialRoomPos))
                    {
                        _potentialNextRoom = roomTemplates.topRooms[Random.Range(0, roomTemplates.topRooms.Count)];
                    }
                    else
                    {
                        randomEnterance = _randomEnteranceRange[Random.Range(0, _randomEnteranceRange.Count)];
                        _randomEnteranceRange.Remove(2);
                    }




                }
                else
                {
                    randomEnterance = _randomEnteranceRange[Random.Range(0, _randomEnteranceRange.Count)];
                    _randomEnteranceRange.Remove(2);
                }

            }

            if (randomEnterance == 3)
            {
                if (roomTemplates.leftRooms.Contains(roomOn))
                {

                    _potentialRoomPos = new Vector2(roomPosOn.x - 1, roomPosOn.y);
                    if (!roomPos.Contains(_potentialRoomPos))
                    {
                        _potentialNextRoom = roomTemplates.rightRooms[Random.Range(0, roomTemplates.rightRooms.Count)];

                    }
                    else
                    {
                        randomEnterance = _randomEnteranceRange[Random.Range(0, _randomEnteranceRange.Count)];
                        _randomEnteranceRange.Remove(3);
                    }



                }
                else 
                {
                    randomEnterance = _randomEnteranceRange[Random.Range(0, _randomEnteranceRange.Count)];
                    _randomEnteranceRange.Remove(3);
                }

            }

            if (_randomEnteranceRange.Count == 0) break;

        }

        if (_potentialNextRoom != null)
        {
            Instantiate(_potentialNextRoom,startingPoint + _potentialRoomPos * new Vector2(width,height),Quaternion.identity);// maybe add room on
            roomOn = _potentialNextRoom;
            roomPosOn = _potentialRoomPos;
            roomPos.Add(roomPosOn);
        }




    }
}
