using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class videoscanemanager : MonoBehaviour
{
    // Start is called before the first frame update
    float timer;
    void Start()
    {
        timer =0;
    }

    // Update is called once per frame
    void Update()
    {
        timer +=1*Time.deltaTime;
        if(timer>31){
            SceneManager.LoadScene(1);
        }
    }
}
