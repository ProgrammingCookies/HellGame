using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_ball : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public int fire_circleDamage = 3;
 


    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {

        Fire_Circle fire_circle = hitInfo.GetComponent<Fire_Circle>();
        if (fire_circle != null)
        {
            fire_circle.Takedamage(fire_circleDamage);
        }



        Destroy(gameObject);
    }
}
