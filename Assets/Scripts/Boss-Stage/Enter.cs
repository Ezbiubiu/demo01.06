
using UnityEngine;

public class Enter : MonoBehaviour
{


    public GameObject e;
    public GameObject needs;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            e.SetActive(true);
        }
        
          
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            e.SetActive(false);
            needs.SetActive(false);
        }
    }
}
