using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    

    private void OnTriggerEnter(Collider collision)
    {
            switch(collision.gameObject.tag)
            {
                case "item0":
                HealthController.health += 20f;
                Destroy(collision.gameObject);
                break;

                case "item1":
                StartCoroutine(SpeedUP());
                Destroy(collision.gameObject);
                break;

                case "item2":
                StartCoroutine(Freeze());
                Destroy(collision.gameObject);
                break;



            }

        
    }

    
    IEnumerator SpeedUP()
    {
        PlayerController.speed += 5f;
        yield return new WaitForSeconds(5);
        PlayerController.speed -= 5f;

    }

    IEnumerator Freeze()
    {
        EnemyController.CanMove = false;
        yield return new WaitForSeconds(3);
        EnemyController.CanMove = true;
    }

}
