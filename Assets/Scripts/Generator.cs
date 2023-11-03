using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public static Generator instance;
    public GameObject[] RoomList;
    public GameObject[] ItemList;
    public static int CurrentRoomCord = 0;
    public Transform player;
    System.Random rnd = new System.Random();


    void Start()
    {
        instance = this;
    }

    
    void Update()
    {
        if(player.position.z > CurrentRoomCord - 10)
        {
            GenerateRoom();
            GenerateItem(); //
        }

        
    }

    void GenerateRoom()
    {
        int roomnum = rnd.Next(0, RoomList.Length);
        CurrentRoomCord += 10;
        Instantiate(RoomList[roomnum], new Vector3(0, 0, CurrentRoomCord), Quaternion.identity);

        
    }

    void GenerateItem()
    {
        int itemnum = rnd.Next(0, ItemList.Length);
        int spawn = rnd.Next(0, 8);
        if(spawn == 1)
        {
            Instantiate(ItemList[itemnum], new Vector3(0, 1, CurrentRoomCord), Quaternion.identity);
        }
    }
}
