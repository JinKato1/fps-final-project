using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXController : MonoBehaviour
{
    public static SFXController instance;

    public AudioSource virus_explosion, clicking_sound, sad_bgm;
    


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
}
