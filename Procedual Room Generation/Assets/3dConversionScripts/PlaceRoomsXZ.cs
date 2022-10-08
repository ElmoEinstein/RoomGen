using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceRoomsXZ : MonoBehaviour
{

    [SerializeField] GameObject corridorX;
    [SerializeField] GameObject corridorZ;

    public int maxRooms = 20;
    public int maxAmountOfRG = 1;

    List<Vector3> roomPos = new List<Vector3>();
    [SerializeField] List<GameObject> roomTypes = new List<GameObject>();




    [SerializeField] GameObject startingIns;
    GameObject roomOnIns;
    GameObject roomOn;

    Vector3 roomPosOn;
    GameObject nextRoom;



    [SerializeField] Vector3 startingPoint;
    [SerializeField] float width;
    [SerializeField] float height;

    [SerializeField] float tileWidth;
    [SerializeField] float tileHeight;

    //remember in game size and not in pixel size;


    void Start()
    {

        roomPosOn = new Vector3(0, 0, 0);
        roomOn = startingIns;
        roomOnIns = Instantiate(startingIns, startingPoint, Quaternion.identity);
        roomPos.Add(roomPosOn);




        Debug.Log(roomPos[0]);
    }

    void Update()
    {
        if (maxRooms > 0)
        {
            GenerateRooms();
            maxRooms--;
        }
        else
        {
            if(maxAmountOfRG > 0)
            {
                GameObject _self = Instantiate(this.gameObject);
                _self.GetComponent<PlaceRoomsXZ>().maxAmountOfRG = maxAmountOfRG - 1;
                _self.GetComponent<PlaceRoomsXZ>().maxRooms = 20;


                Destroy(gameObject);

            }else Destroy(gameObject);
        }



    }


    void GenerateRooms()
    {
        List<int> _randomEnteranceRange = new List<int> { 0, 1, 2, 3 };
        Vector3 _potentialRoomPos = new Vector3(0, 0, 0);
        Vector3 _corridorDir = new Vector3(0, 0, 0);

        GameObject _nextRoom = null;

        int randomEnterance = _randomEnteranceRange[Random.Range(0, _randomEnteranceRange.Count)];

        while (_nextRoom != true)
        {


            if (randomEnterance == 0)
            {
                _potentialRoomPos = new Vector3(roomPosOn.x, 0, roomPosOn.z + 1);
                if (!roomPos.Contains(_potentialRoomPos))
                {
                    _nextRoom = roomTypes[Random.Range(0, roomTypes.Count)];

                    _corridorDir = new Vector3(0, 0, -1);


                }
                else
                {
                    randomEnterance = _randomEnteranceRange[Random.Range(0, _randomEnteranceRange.Count)];
                    _randomEnteranceRange.Remove(0);

                }

            }

            if (randomEnterance == 1)
            {
                _potentialRoomPos = new Vector3(roomPosOn.x + 1, 0, roomPosOn.z);
                if (!roomPos.Contains(_potentialRoomPos))
                {
                    _nextRoom = roomTypes[Random.Range(0, roomTypes.Count)];

                    _corridorDir = new Vector3(-1, 0, 0);


                }
                else
                {
                    randomEnterance = _randomEnteranceRange[Random.Range(0, _randomEnteranceRange.Count)];
                    _randomEnteranceRange.Remove(1);


                }

            }

            if (randomEnterance == 2)
            {
                _potentialRoomPos = new Vector3(roomPosOn.x, 0, roomPosOn.z - 1);
                if (!roomPos.Contains(_potentialRoomPos))
                {
                    _nextRoom = roomTypes[Random.Range(0, roomTypes.Count)];

                    _corridorDir = new Vector3(0, 0, 1);


                }
                else
                {
                    randomEnterance = _randomEnteranceRange[Random.Range(0, _randomEnteranceRange.Count)];
                    _randomEnteranceRange.Remove(2);
                }

            }

            if (randomEnterance == 3)
            {
                _potentialRoomPos = new Vector3(roomPosOn.x - 1, 0, roomPosOn.z);
                if (!roomPos.Contains(_potentialRoomPos))
                {
                    _nextRoom = roomTypes[Random.Range(0, roomTypes.Count)];
                    _corridorDir = new Vector3(1, 0, 0);


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
            roomPos.Add(roomPosOn);
            if (randomEnterance == 1 || randomEnterance == 3)
            {


                for (int i = 0; i <= width / tileWidth; i++)
                {



                    {

                        Instantiate(corridorX, (startingPoint + new Vector3(width * _potentialRoomPos.x, 0 * _potentialRoomPos.y, height * _potentialRoomPos.z)) + new Vector3(tileWidth * i * _corridorDir.x, 0, 0), Quaternion.identity);

                    }



                }
            }


            if (randomEnterance == 0 || randomEnterance == 2)
            {

                for (int i = 0; i <= height / tileHeight; i++)
                {



                    Instantiate(corridorZ, (startingPoint + new Vector3(width * _potentialRoomPos.x, 0 * _potentialRoomPos.y, height * _potentialRoomPos.z)) + new Vector3(0, 0, tileHeight * i * _corridorDir.z), Quaternion.identity);


                }
            }


            Instantiate(_nextRoom, startingPoint + new Vector3(width * _potentialRoomPos.x, 0 * _potentialRoomPos.y, height * _potentialRoomPos.z), Quaternion.identity);

        }
    }
}
