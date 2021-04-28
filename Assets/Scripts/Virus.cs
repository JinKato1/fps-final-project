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
/*        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector3(0, 0, 0);
            is_stopped = true;
        }
*/
    }

    public void TakeDamage(int damageAmount)
    {
        //taking_damage_sfx.Play(taking_damage_sfx.);
        currentHealth = currentHealth - damageAmount;

        if (currentHealth <= 0)
        {
            //SFXController.instance.virus_explosion.Play();
            AudioController.instance.VirusExplosion();
            //SFXController.instance.virus_explosion.PlayOneShot(SFXController.instance.virus_explosion.clip);
            Instantiate(explosion_effect, transform.position, transform.rotation);
            Destroy(gameObject);
            
        }
    }

/*    void OnCollisionEnter(Collision collision)
    {
        print("Collision with Player");
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(damage);

        }
        Destroy(gameObject);

    }*/
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().TakeDamage(damage);
            Destroy(gameObject);

        }
        

    }
}
