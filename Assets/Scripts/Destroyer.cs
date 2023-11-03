using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    
    /*private void Update()
    {
        if(transform.position.z < enemy.position.z)
        {
            Destroy(gameObject);
        }
    }*/



    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("room"))
        {
            Destroy(other.gameObject);
        }
        else if(other.CompareTag("Player"))
        {
            GameOver();
        }
    }

    void GameOver()
    {

    }
}
