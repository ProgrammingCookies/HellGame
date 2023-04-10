using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Spell : MonoBehaviour
{
    public bool playerCollision = false;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
  
    }

    public void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.tag == "Player")
        {
            playerCollision = true;
        }
    }


    public void OnTriggerExit2D(Collider2D other)
    {
        if (playerCollision)
        {
            playerCollision = false;
        }
    }

    public void destroy()
    {

        Destroy(gameObject);
    }
}
