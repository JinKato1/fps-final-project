using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Virus : MonoBehaviour
{
    public float move_speed;
    public Rigidbody rb;
    public int currentHealth = 5;
    public int damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        /*      transform.LookAt(new Vector3(0.0f, 1.6f, 0f));
                rb.velocity = transform.forward * move_speed;*/
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(new Vector3(0.0f, 1.6f, 0f));
        rb.velocity = transform.forward * move_speed;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth = currentHealth - damageAmount;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(damage);


        }
        Destroy(gameObject);

    }
}
