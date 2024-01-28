using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
     public void SonrakiSahneyeGec()
    {
        SceneManager.LoadScene(2);
    }
    public void ExıtGame(){
        Application.Quit();
    }
    public void RestartGame(){
        SceneManager.LoadScene(2);
    }
    
    public void videoscanecontroller(){

    }
}
