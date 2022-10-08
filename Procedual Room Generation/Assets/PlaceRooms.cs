using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceRooms : MonoBehaviour
{

    [SerializeField] GameObject corridorX;
    [SerializeField] GameObject corridorY;


    List<Vector2> roomPos = new List<Vector2>();
    [SerializeField] List<GameObject> roomTypes = new List<GameObject>();




    [SerializeField] GameObject startingIns;
    GameObject roomOnIns;
    GameObject roomOn;

    Vector2 roomPosOn;
    GameObject nextRoom;



    [SerializeField] Vector2 startingPoint;
    [SerializeField] float width;
    [SerializeField] float height;

    [SerializeField] float tileWidth;
    [SerializeField] float tileHeight;

    //remember in game size and not in pixel size;

    
    void Start()
    {

        roomPosOn = new Vector2(0, 0);
        roomOn = startingIns;
        roomOnIns = Instantiate(startingIns, startingPoint, Quaternion.identity);
        roomPos.Add(roomPosOn);

        


        Debug.Log(roomPos[0]);
    }

    void Update()
    {
        GenerateRooms();



    }


    void GenerateRooms()
    {
        List<int> _randomEnteranceRange = new List<int> { 0, 1, 2, 3 };
        Vector2 _potentialRoomPos = new Vector2(0, 0);
        Vector2 _corridorDir = new Vector2(0,0);

        GameObject _nextRoom = null;

        int randomEnterance = _randomEnteranceRange[Random.Range(0, _randomEnteranceRange.Count)];

        while (_nextRoom != true)
        {


            if (randomEnterance == 0)
            {
                _potentialRoomPos = new Vector2(roomPosOn.x, roomPosOn.y + 1);
                if (!roomPos.Contains(_potentialRoomPos))
                {
                    _nextRoom = roomTypes[Random.Range(0,roomTypes.Count)];

                    _corridorDir = new Vector2(0,-1);
                    

                }
                else
                {       
                    randomEnterance = _randomEnteranceRange[Random.Range(0, _randomEnteranceRange.Count)];
                    _randomEnteranceRange.Remove(0);

                }

            }

            if (randomEnterance == 1)
            {
                _potentialRoomPos = new Vector2(roomPosOn.x + 1, roomPosOn.y);
                if (!roomPos.Contains(_potentialRoomPos))
                {
                    _nextRoom = roomTypes[Random.Range(0, roomTypes.Count)];

                    _corridorDir = new Vector2(-1, 0);


                }
                else
                {
                    randomEnterance = _randomEnteranceRange[Random.Range(0, _randomEnteranceRange.Count)];
                    _randomEnteranceRange.Remove(1);


                }

            }

            if (randomEnterance == 2)
            {
                _potentialRoomPos = new Vector2(roomPosOn.x, roomPosOn.y - 1);
                if (!roomPos.Contains(_potentialRoomPos))
                {
                    _nextRoom = roomTypes[Random.Range(0, roomTypes.Count)];

                    _corridorDir = new Vector2(0, 1);


                }
                else
                {
                    randomEnterance = _randomEnteranceRange[Random.Range(0, _randomEnteranceRange.Count)];
                    _randomEnteranceRange.Remove(2);
                }

            }

            if (randomEnterance == 3)
            {
                _potentialRoomPos = new Vector2(roomPosOn.x - 1, roomPosOn.y);
                if (!roomPos.Contains(_potentialRoomPos))
                {
                    _nextRoom = roomTypes[Random.Range(0, roomTypes.Count)];
                    _corridorDir = new Vector2(1, 0);


                }
                else
                {
                    randomEnterance = _randomEnteranceRange[Random.Range(0, _randomEnteranceRange.Count)];
                    _randomEnteranceRange.Remove(3);
  
                }
            }


            if (_randomEnteranceRange.Count == 0) break;


        }

        if (_nextRoom != null)
        {
            //generate room


            //generate corridors here 


            roomOn = _nextRoom;
            roomPosOn = _potentialRoomPos;
           // Instantiate(_nextRoom, startingPoint + _potentialRoomPos * new Vector2(width, height), Quaternion.identity);
            roomPos.Add(roomPosOn);
            if (randomEnterance == 1 || randomEnterance == 3)
            {
                //bool _hasFoundExit = false;


                for (int i = 0; i <= width / tileWidth; i++)
                {

                    

                    //if (_hasFoundExit == true)
                    {

                        Instantiate(corridorX,(startingPoint + _potentialRoomPos * new Vector2(width, height)) + new Vector2(tileWidth * i * _corridorDir.x,0) , Quaternion.identity);

                    }

                    //bool _overlapCircleExitWall = Physics2D.OverlapCircle((startingPoint + _potentialRoomPos * new Vector2(width, height)) + new Vector2(tileWidth * i * _corridorDir.x, 0), tileWidth/2-.05f);
                    //if (_overlapCircleExitWall == true) _hasFoundExit = !_hasFoundExit;

                }
            }      


            if (randomEnterance == 0 || randomEnterance == 2)
            {

                for (int i = 0; i <= height / tileHeight; i++)
                {

                    
                    
                        Instantiate(corridorY, (startingPoint + _potentialRoomPos * new Vector2(width, height)) + new Vector2(0, tileHeight * i * _corridorDir.y) , Quaternion.identity);

                    
                }
            }

            Instantiate(_nextRoom, startingPoint + _potentialRoomPos * new Vector2(width, height), Quaternion.identity);

        }
    }
}
