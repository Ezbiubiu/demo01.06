using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    public void playgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        GlobalControl.Instance.HP = 100;
        GlobalControl.Instance.MaxHP = 100;
        GlobalControl.Instance.level = 0;


    }
    public void quitgame()
    {
        Application.Quit();
    }
}
