using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pausemenu : MonoBehaviour
{
    public GameObject Pmenu;


    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        Pmenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        Pmenu.SetActive(false);
        Time.timeScale = 1f;
    }



    // public void b2menu()
    // {
    //         if(SceneManager.GetActiveScene().buildIndex == 1)
    //         {
    //             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+2);

    //         }
    //         if(SceneManager.GetActiveScene().buildIndex == 2)
    //             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);

    // }

}
