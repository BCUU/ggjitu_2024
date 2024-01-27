using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class addHorn : MonoBehaviour
{
    public Image filledImage;
    public float yeniFilledDegeri = 0.5f;
    private AudioSource audioSource;
    public AudioClip horn;
    private void Start()
    {
        audioSource=gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player")) 
        {
            filledImage.fillAmount += yeniFilledDegeri;
            audioSource.PlayOneShot(horn);
            StartCoroutine(waitforaudio());
            //gameObject.SetActive(false);
        }
    }
    IEnumerator waitforaudio(){
        yield return new  WaitForSecondsRealtime(1f);
        Destroy(gameObject);
    }
}
