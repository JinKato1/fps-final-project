using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 1;
    public float bullet_duration;
    public float speed;

    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        bullet_duration = bullet_duration - Time.deltaTime;

        if (bullet_duration <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Virus")
        {
            other.gameObject.GetComponent<Virus>().TakeDamage(damage);
        }

        Destroy(gameObject);
    }



}
