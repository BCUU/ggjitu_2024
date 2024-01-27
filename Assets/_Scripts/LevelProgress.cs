using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgress : MonoBehaviour
{

    public float totalLaugh = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseProgressValue()
    {
        
        this.GetComponent<Slider>().value += 1f / totalLaugh;
        Debug.Log(this.GetComponent<Slider>().value);
    }
}
