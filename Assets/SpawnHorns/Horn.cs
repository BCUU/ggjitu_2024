using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Horn : MonoBehaviour
{
    public Image filledImage;
    public float yeniFilledDegeri = 0.1f;
    private AudioSource audioSource;
    public AudioClip horn;
    private void Start()
    {
        audioSource=gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("TAG")) 
        {
            
            filledImage.fillAmount += yeniFilledDegeri;
            audioSource.PlayOneShot(horn);
            StartCoroutine(waitforaudio());
             if (filledImage.fillAmount > 1.0f)
            {
                filledImage.fillAmount = 1.0f;
            }
            collision.gameObject.SetActive(false);

        }
    }
    IEnumerator waitforaudio(){
        yield return new  WaitForSecondsRealtime(1f);
        //gameObject.SetActive(false);
    }
}
