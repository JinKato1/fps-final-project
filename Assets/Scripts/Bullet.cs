using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public int damage = 1;
    public float bullet_duration;
    public float speed;

    public Rigidbody rb;
    public GameObject player;

    public Text score_text;

    // Start is called before the first frame update
    void Start()
    {
       // rb.velocity = transform.forward * speed;
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
            Player.instance.AddPoints(1);
        }

        Destroy(gameObject);
    }

    public void SetVelocity(Vector3 point)
    {
        transform.LookAt(point);
        rb.velocity = transform.forward * speed;
    }

}
