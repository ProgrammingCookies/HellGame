using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Circle : MonoBehaviour
{
    public float offset;
    public GameObject fireball;
    public Transform shotPoint;
    public float delayInSeconds;
    public float health = 5;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        StartCoroutine(ShootDelay());
    }

    // Update is called once per frame
    void Shoot()
    {

    }

    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(delayInSeconds);
        Instantiate(fireball, shotPoint.position, transform.rotation);
        // Destroy(gameObject);
    }

    public void Takedamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }

    }

    void Die()
    {
        Destroy(gameObject);
    }
}
