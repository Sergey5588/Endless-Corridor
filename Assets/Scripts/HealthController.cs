using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class HealthController : MonoBehaviour
{
    public Image bar;
    public static float health = 100f;
    public static float maxhealth = 100f;
    public GameObject GameOverMenu;
    public Transform enemy;
    private Animator deathAnim;
    public GameObject anim;
    public TextMeshProUGUI best;
    public TextMeshProUGUI Dist;
    public static bool IsOver = false;


    private void Start()
    {
        deathAnim = anim.GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        if (health <= 0)
        {
            GameOver();
        }
        else if (!PlayerController.IsOnPause)
        {
            health -= 4f / Vector3.Distance(transform.position, enemy.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        best.text = "YOUR BEST ROOM:" + Generator.CurrentRoomCord / 10;
        Dist.text = Mathf.Round(Vector3.Distance(transform.position, enemy.position)/10) + "m";
        health = Mathf.Clamp(health, 0f, maxhealth);
        float fill = health / maxhealth;
        bar.fillAmount = fill;

        


        if(gameObject.transform.position.x < -10f || gameObject.transform.position.x > 10f)
        {
            GameOver();
        }

        
        
    }

    void GameOver()
    {
        IsOver = true;
        Time.timeScale = 0;
        GameOverMenu.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        deathAnim.SetBool("IsDeath", true);
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("enemy"))
        {
            health = 0;
            GameOver();
        }
    }

    public void Respawn()
    {
        IsOver = false;
        Time.timeScale = 1;
        health = 100f;
        maxhealth = 100f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Generator.CurrentRoomCord = -10;
        PlayerController.speed = 15f;
        EnemyController.CanMove = true;
        
    }
}
