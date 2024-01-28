using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelProgress : MonoBehaviour
{
    [SerializeField] AudioClip sadMusic;
    [SerializeField] AudioClip happyMusic;
    private int tickled;
    private AudioSource audioSource;

    public float totalLaugh = 10f;

    // Start is called before the first frame update
    void Start()
    {
        audioSource=this.GetComponent<AudioSource>();
        audioSource.clip = sadMusic;
        audioSource.volume = 1;
        audioSource.Play();
        tickled = 0;
    }

bool x=false;
    // Update is called once per frame
    void Update()
    {
        if(this.GetComponent<Slider>().value==1){
            SceneManager.LoadScene(3);
        }
        if (this.GetComponent<Slider>().value>0.5&& x==false)
        {
            audioSource.clip = happyMusic;
            audioSource.Play();
            x=true;
            
                
        }
    }

    public void IncreaseProgressValue()
    {
        
        this.GetComponent<Slider>().value += 1f / totalLaugh;
        Debug.Log(this.GetComponent<Slider>().value);
        tickled++;
        if(tickled / totalLaugh < 0.5f)
        {
            audioSource.volume -= 2f / totalLaugh;
        }
        else if(tickled / totalLaugh > 0.5f)
        {
            audioSource.volume += 2f / totalLaugh - 0.5f ;
        }
    }
}
