using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public static Player instance;

    public Transform fire_position;
    public Bullet bullet;

    public Slider health_bar;
    public Text life_text, score_text;
    public GameObject pause_screen;

    public int damage = 1;
    public int current_health;
    public int current_score = 0;

    public AudioSource taking_damage_sfx;

    public Camera main_cam;

    float x = Screen.width / 2;
    float y = Screen.height / 2;

    Ray ray;

    private void Awake()
     {
            instance = this;
     }
    // Start is called before the first frame update
    void Start()
    {
        health_bar.value = current_health;
        life_text.text = "Life: " + current_health;
    }

    // Update is called once per frame
    void Update()
    {
        if (!pause_screen.activeInHierarchy)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Bullet bullet1 = Instantiate(bullet, fire_position.position, fire_position.rotation);
                RaycastHit hit;

                ray = main_cam.ScreenPointToRay(new Vector3(x, y, 0));
                
                if (Physics.Raycast(ray, out hit, 50))
                {
                    bullet1.SetVelocity(hit.point);
                }
                else
                {
                    bullet1.SetVelocity(fire_position.position + fire_position.forward * 40f);
                }

            }
        }
    }


    public void TakeDamage(int damage_amount)
    {
        current_health = current_health - damage_amount;

        if (current_health <= 0)
        { 
            SceneManager.LoadScene("game-over");
        }
        //sound effect
        taking_damage_sfx.PlayOneShot(taking_damage_sfx.clip);

        health_bar.value = current_health;
        life_text.text = "Life: " + current_health;

    }

    public void AddPoints(int points)
    {
        current_score += points;
        score_text.text = current_score.ToString();
    }

}
