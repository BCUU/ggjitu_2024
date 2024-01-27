using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCInteraction : MonoBehaviour
{

    [SerializeField] GameObject pressE;
    [SerializeField] GameObject levelProgress;

    private Animator animator;
    private bool tickleAvailable;
    private NPC tickledNPC;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        tickleAvailable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && tickleAvailable)
        {
            Debug.Log("pressed E");
            StartCoroutine("TickleNPC");
            pressE.SetActive(false);
            tickleAvailable = false;
            
            
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            pressE.SetActive(true);
            tickleAvailable = true;
            tickledNPC=other.GetComponent<NPC>();
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            pressE.SetActive(false);
            tickleAvailable = false;
        }
    }

    private IEnumerator TickleNPC()
    {
        animator.SetTrigger("Tickle");
        yield return new WaitForSeconds(0.5f);
        tickledNPC.Tickled();
        levelProgress.GetComponent<LevelProgress>().IncreaseProgressValue();
        yield return new WaitForSeconds(0.5f);
        animator.SetTrigger("Idle");
    }
}

