using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Virus : MonoBehaviour
{
    public float move_speed;
    public Rigidbody rb;
    public int currentHealth = 5;
    public int damage = 1;
    public bool is_stopped = false; 
    //audio 
    public AudioSource taking_damage_sfx;

    public GameObject explosion_effect;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(new Vector3(0.0f, 0.5f, 0f));
        rb.velocity = transform.forward * move_speed;
    }
     
    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth = currentHealth - damageAmount;

        if (currentHealth <= 0)
        {

            AudioController.instance.VirusExplosion();
            Instantiate(explosion_effect, transform.position, transform.rotation);
            Destroy(gameObject);
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().TakeDamage(damage);
            Destroy(gameObject);

        }
    }
}
