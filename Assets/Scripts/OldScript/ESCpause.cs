using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ESCpause : MonoBehaviour
{
     bool isStop = true;
    public GameObject Menu;


    public void OnResume()
    {
        Time.timeScale = 1f;
        Menu.SetActive(false);
    }

    public void OnRestart()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1f;
        }
        if(SceneManager.GetActiveScene().buildIndex ==2)
        {
            // UnityEngine.SceneManagement.SceneManager.LoadScene(2);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1f;
        }
    }   


    void backMainmenu()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            Time.timeScale = 1f;
        }
        if(SceneManager.GetActiveScene().buildIndex ==2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
            Time.timeScale = 1f;
        }
    }


    void Update()
    {
        if (isStop == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 0;
                isStop = false;
                Menu.SetActive(true);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 1;
                isStop = true;
                Menu.SetActive(false);
            }
        }
    }
}
