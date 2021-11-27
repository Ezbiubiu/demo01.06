
using UnityEngine;

public class Enter : MonoBehaviour
{


    public GameObject e;
<<<<<<< Updated upstream
    public GameObject n;
=======
    // public GameObject n;
>>>>>>> Stashed changes
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            e.SetActive(true);
        }
        
          
    }
<<<<<<< Updated upstream
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            e.SetActive(false);
            n.SetActive(false);
        }
    }
=======
    // void OnTriggerExit2D(Collider2D collision)
    // {
    //     if (collision.tag == "Player")
    //     {
    //         e.SetActive(false);
    //         n.SetActive(false);
    //     }
    // }
>>>>>>> Stashed changes
}
