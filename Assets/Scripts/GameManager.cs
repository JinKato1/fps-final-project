using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject virus;
    public Vector3 position;
    float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Invoke("SpawnVirus", 1.0f);

    }

    // Update is called once per frame
    void Update()
    {
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
        //Rigidbody instance = Instantiate(virus,  );
        //instance.velocity = Random.insideUnitSphere * 5.0f;
    }
}
