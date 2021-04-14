using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;

    //BGM
    public AudioSource bgm;

    //SFX Player
    public AudioSource player_shooting, player_taking_damage;

    //SFX Virus
    public AudioSource virus_explosion;

    //SFX Menu
    public AudioSource menu_start_button, menu_quit_button;

    private void Awake()
    {
        instance = this;

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Bgm()
    {
        bgm.Play();
    }
    public void PlayerShooting()
    {
        player_shooting.PlayOneShot(player_shooting.clip);
    }

    public void PlayerTakingDamage()
    {
        player_taking_damage.PlayOneShot(player_taking_damage.clip);
    }

    public void VirusExplosion()
    {
        virus_explosion.PlayOneShot(virus_explosion.clip);
    }

    public void MenuStartButton()
    {
        menu_start_button.PlayOneShot(menu_start_button.clip);
    }

    public void MenuQuitButton()
    {
        menu_quit_button.PlayOneShot(menu_quit_button.clip);
    }
}
