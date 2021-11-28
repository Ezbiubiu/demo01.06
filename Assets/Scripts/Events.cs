using UnityEngine.SceneManagement;
using UnityEngine;

public class Events : MonoBehaviour
{
    //relpay level 
    public void ReplayLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void QuitGame(){

        Application.Quit();
    }
}
