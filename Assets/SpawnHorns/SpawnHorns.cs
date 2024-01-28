using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class SpawnHorns : MonoBehaviour
{

    [SerializeField] GameObject horn;

    private List<GameObject> hornList;

    private float timer;


    // Start is called before the first frame update
    void Start()
    {
        hornList = new List<GameObject>();
        spawnHorn(30);

        timer = 3f;

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            int n = Random.Range(2, 5);
            ActivateHorn(n);
            timer = Random.Range(3, 12);
        }
    }

    private void spawnHorn(int n)
    {
        for (int i = 0; i < n; i++)
        {
            GameObject hornObject = Instantiate(horn, Vector3.zero, transform.rotation);
            hornList.Add(hornObject);
            hornObject.SetActive(false);

        }

    }

    private void ActivateHorn(int n)
    {
        // int x =0;
        // int retryPos = 0;
        // while (retryPos < n)
        // {

        //     Vector3 pos = new Vector3(Random.Range(-15, 15), 1f, Random.Range(-8, 8));
        //     Collider[] CollisionWithAnything = Physics.OverlapBox(pos, Vector3.one, Quaternion.identity);
        //     if (CollisionWithAnything.Length == 0)
        //     {
        //         Debug.Log("asdasddas");
        //         int beginning = 0;
                // for (int k = 0; k < hornList.Count; k++)
                // {
                //     if (!hornList[k].activeSelf)
                //     {
                //         beginning = k;
                //         Debug.Log("beginning:" + beginning);
                //         break;
                //     }
                // }
        //         hornList[beginning].transform.position = pos;
        //         hornList[beginning].SetActive(true);
        //         retryPos++;
        //         x++;
        //         if(x==10){
        //             break;
        //         }
        //     }
            


        //     Debug.Log("spawn");
        // }

        for(int i=0; i<n; i++){
            Vector3 pos = new Vector3(Random.Range(-15, 15), 0.3f, Random.Range(-8, 8));
            int beginning=0;
            for (int k = 0; k < hornList.Count; k++)
                    {
                        if (!hornList[k].activeSelf)
                        {
                            beginning = k;
                           // Debug.Log("beginning:" + beginning);
                            break;
                        }
                    }
            hornList[beginning].transform.position = pos;        
            hornList[beginning].SetActive(true);
        }
        

    }


}

