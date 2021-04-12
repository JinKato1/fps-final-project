using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject virus;
    public Vector3 position;
    float timer = 0.0f;

    public GameObject pause_screen;

    //scenes
    public string menu_scene, game_scene;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        //hiding the pause screen
        pause_screen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !pause_screen.activeInHierarchy)
        {
            Pause();
        }

        if(timer <= 1f)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            SpawnVirus();
        }


    }
    void SpawnVirus()
    {
        int num = Random.Range(0, 4);

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
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
    }

    public void Unpause()
    {
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
