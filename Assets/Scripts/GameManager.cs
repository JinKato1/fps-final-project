﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject virus, green_virus, red_virus;
    public Vector3 position;
    float timer = 0.0f;
    float spawn_timer = 0.0f;
    public float spawning_interval;
    public float spawn_rate;
    public float red_spawn_rate;

    public GameObject pause_screen, game_ui, game_over_screen;

    //scenes
    public string menu_scene, game_scene;




    // Start is called before the first frame update
    void Start()
    {
        //Virus moving audio 
        AudioController.instance.mixer.SetFloat("Master", 0);
        
        game_ui.SetActive(true);
        pause_screen.SetActive(false);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update(){

        if (Input.GetKeyDown(KeyCode.Escape) && !pause_screen.activeInHierarchy && !game_over_screen.activeInHierarchy)
        {
            Pause();
        }

        if (timer <= 1f)
        {
            timer += Time.deltaTime;

        }
        else
        {
            spawning_interval = spawning_interval - spawn_rate;
            timer = 0;
        }


        if (spawn_timer <= spawning_interval)
        {
            spawn_timer += Time.deltaTime;
            
        }
        else
        {
            spawn_timer = 0;
            SpawnVirus();
        }


    }
    void SpawnVirus()
    {
        int num = Random.Range(0, 4);

        float ran_num = Random.Range(0f, 1f);

        if (ran_num < red_spawn_rate)
        {
            virus = red_virus;
        }
        else
        {
            virus = green_virus;
        }
  

        if (num == 0)
        {
            position = new Vector3(50, 1.6f, Random.Range(-50, 50));
        }
        else if (num == 1)
        {
            position = new Vector3(-50, 1.6f, Random.Range(-50, 50));
        }
        else if (num == 2)
        {
            position = new Vector3(Random.Range(-50, 50), 1.6f, 50);
        }
        else
        {
            position = new Vector3(Random.Range(-50, 50), 1.6f, -50);
        }

        Instantiate(virus, position, Quaternion.identity);

    }


    //Functionality for the pause screen 

    public void Pause()
    {

        pause_screen.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
    }

    public void Unpause()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        pause_screen.SetActive(false);
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(menu_scene);
    }

    public void Restart()
    {
        SceneManager.LoadScene(game_scene);
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
