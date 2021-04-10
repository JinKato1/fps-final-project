using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text score_text;

    // Start is called before the first frame update
    void Start()
    {
        score_text.text = "Your Score: " + Player.instance.current_score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
