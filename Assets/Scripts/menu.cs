using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    public AudioSource start_sound, quit_sound;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
/*
    public void StartClicked2()
    {
        SFXController.instance.clicking_sound.PlayOneShot(SFXController.instance.clicking_sound.clip);
        SceneManager.LoadScene("main");
    }
*/
    public void StartClicked()
    {
        start_sound.PlayOneShot(start_sound.clip);
        StartCoroutine(StartGame());
    }

    public void QuitClicked()
    {
        quit_sound.PlayOneShot(quit_sound.clip);
        StartCoroutine(QuitGame());
    }

    public void BackToMenuClicked()
    {
        quit_sound.PlayOneShot(quit_sound.clip);
        StartCoroutine(BackToMenu());
    }
    /*
        public void QuitGame()
        {
            Application.Quit();
        }*/


    IEnumerator StartGame()
    {
        yield return new WaitForSecondsRealtime(1);
        SceneManager.LoadScene("main");
    }

    IEnumerator QuitGame()
    {
        yield return new WaitForSecondsRealtime(1);
        Application.Quit();
    }

    IEnumerator BackToMenu()
    {
        yield return new WaitForSecondsRealtime(1);
        SceneManager.LoadScene("menu");
    }


}
