using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform fire_position;
    /*    public static Player this_instance;*/
    public GameObject bullet;

    public int damage = 1;
    public int current_health;
    /*
        private void Awake()
        {
            this_instance = this;
        }*/
    // Start is called before the first frame update
    void Start()
    {
        UI.instance.health_slider.maxValue = current_health;
        UI.instance.health_slider.value = current_health;
        UI.instance.health_text.text = "Life: " + current_health;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, fire_position.position, fire_position.rotation);
        }

    }


    public void TakeDamage(int damage_amount)
    {
        print("taken damage");
        current_health = current_health - damage_amount;

        if (current_health <= 0)
        {
            Destroy(gameObject);
        }
        UI.instance.health_slider.value = current_health;
        UI.instance.health_text.text = "Life: " + current_health;


    }
}
