using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pausemenu : MonoBehaviour
{
    public GameObject Pmenu;
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
    public void b2menu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);

    }

}
