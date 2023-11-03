using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform cam;
    public GameObject Menu;
    public static float speed = 15f;
    public float sensivity = 1200f;
    
    public float rotation = 0f;
    public float xrotation = 0f;
    public float s = 1f;
    public static bool IsOnPause = false;

    void Start()
    {
        if(PlayerPrefs.HasKey("Sens"))
        {
            sensivity = PlayerPrefs.GetFloat("Sens");
        }
        else
        {
            sensivity = 1200f;
        }
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        

    }

    void Update()
    {
        if (s != 0)
        {
            sensivity = s;
        }
        else if(!PlayerPrefs.HasKey("Sens"))
        {
            sensivity = 1200f;
        }
        if (IsOnPause || HealthController.IsOver)
        {
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
        else
        {
            Time.timeScale = 1;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * sensivity;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * sensivity;
        rotation -= mouseX;
        xrotation -= mouseY;
        
        transform.localRotation = Quaternion.Euler(0f, -rotation, 0f);
        xrotation = Mathf.Clamp(xrotation, -90f, 90f);
        cam.localRotation = Quaternion.Euler(xrotation, 0f, 0f);


        Rigidbody rb = GetComponent<Rigidbody>();
        Vector3 localVelocity = new Vector3(Input.GetAxis("Horizontal") * speed, 0, Input.GetAxis("Vertical") * speed);
        Vector3 globalVelocity = transform.TransformDirection(localVelocity);
        rb.velocity = globalVelocity;

        if(Input.GetKey(KeyCode.Escape) && HealthController.IsOver == false)
        {
            Menu.SetActive(true);
            IsOnPause = true;
        }

    }

    public void Resume()
    {
        Menu.SetActive(false);
        IsOnPause = false;
    }
    public void Exit()
    {
        Application.Quit();
    }

    public void SetSens(float sens)
    {
        s = sens;
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetFloat("Sens", sensivity);
    }



}