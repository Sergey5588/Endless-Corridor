using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float curZ = -10f;
    public float tax = 0.01f;
    public static bool CanMove = true;

    void FixedUpdate()
    {
        if (CanMove)
        {
            transform.position = new Vector3(0, 5, curZ += tax);
            tax += 0.0001f;
        }

        

    }

     


}
