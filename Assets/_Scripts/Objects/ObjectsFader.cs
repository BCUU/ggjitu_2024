using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsFader : MonoBehaviour
{
    public float fadeSpeed,fadeAmount;
    float originalOpacity;
    public bool doFade=false;
    Material Mat;
    void Start(){
        Mat = GetComponent<Renderer>().material;
        originalOpacity = Mat.color.a;
    }
    
    private void Update()
    {
        if(doFade){
            FadeNow();
        }
        else{
            resetFade();
        }
    }
    void FadeNow(){
        Color currentColor=Mat.color;
        Color smoothColor= new Color(currentColor.r,currentColor.g,currentColor.b,Mathf.Lerp(currentColor.a,fadeAmount,fadeSpeed*Time.deltaTime));
        Mat.color=smoothColor;
    }
    void resetFade(){
        Color currentColor=Mat.color;
        Color smoothColor= new Color(currentColor.r,currentColor.g,currentColor.b,Mathf.Lerp(currentColor.a,originalOpacity,fadeSpeed*Time.deltaTime));
        Mat.color=smoothColor;
    }

}
