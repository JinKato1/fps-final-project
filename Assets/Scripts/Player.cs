using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public static Player instance;

    public Transform fire_position;
    public GameObject bullet;

    public Slider health_bar;
    public Text life_text, score_text;

    public int damage = 1;
    public int current_health;
    public int current_score = 0;

    public GameObject pause_screen;

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
                Instantiate(bullet, fire_position.position, fire_position.rotation);
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

        health_bar.value = current_health;
        life_text.text = "Life: " + current_health;
    }
    
    public void AddPoints(int points)
    {
        current_score += points;
        score_text.text = current_score.ToString();
    }

}
