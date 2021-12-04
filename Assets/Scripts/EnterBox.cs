
using UnityEngine;

public class EnterBox : MonoBehaviour
{


    public GameObject e;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Player")
        {
            e.SetActive(true);
        }
        
          
    }
    void OnTriggerExit2D(Collider2D collision)
    {

        GlobalControl.Instance.MaxHP += 10f;
        if (collision.tag == "Player")
        {
            e.SetActive(false);

        }
    }
}
