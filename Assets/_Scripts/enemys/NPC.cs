using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NPC : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] AudioClip[] laughs;
    [SerializeField]  GameObject levelProgress;


    private AudioSource audioSource;
    void Start()
    {
        audioSource= GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void addpoint()
    {
        levelProgress.GetComponent<LevelProgress>().IncreaseProgressValue();
    }
    

    public void Tickled()
    {
        this.GetComponent<CapsuleCollider>().enabled = false;
        transform.tag = "Tickled-NPC";
        StartCoroutine("Laugh");
    }
    private IEnumerator Laugh()
    {
        AudioClip audioClip = laughs[Random.Range(0,laughs.Length)];
        audioSource.PlayOneShot(audioClip);
        yield return null;
    }
}

