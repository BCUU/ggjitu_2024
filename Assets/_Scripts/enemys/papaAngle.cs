using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR.WSA;
using UnityEngine.UI;


public class papaAngle : MonoBehaviour
{
    public GameObject panell;
    public float algilamaMesafesi = 10f;
    public float hareketHizi = 5f;
    public Transform hedef;
    public Light spotlight;
    public Color red1, green;
    NavMeshAgent navMeshAgent;
    void Start(){
        navMeshAgent=gameObject.GetComponent<NavMeshAgent>();
        MoveToRandomDestination();
    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player")){
            //Time.timeScale=0f;
            panell.SetActive(true);

        }
    }
    void Update()
    {
        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.5f&& hedef==null)
        {
            // Yeni bir hedef belirle ve hareket et
            MoveToRandomDestination();
        }
        // Düşmanın ortasından biraz yukarıda başlayarak yukarıya doğru bir ışın oluştur
        Vector3 rayBaslangicNoktasi = transform.position + new Vector3(0f, 0.5f, 0f);
        Vector3 rayYonu = transform.forward;

        RaycastHit hit;

        if (Physics.Raycast(rayBaslangicNoktasi, rayYonu, out hit, algilamaMesafesi))
        {
            //Debug.Log("Çarpışan Nesne: " + hit.collider.gameObject.name);
            // Işın bir nesneye çarptı, çarptığı nesnenin etiketini kontrol et
            if (hit.collider.CompareTag("Player"))
            {
                // Eğer çarptığı nesne oyuncu ise, hedefi güncelle
                hedef = hit.collider.transform;
                Debug.Log("Oyuncu görüldü!");
                spotlight.GetComponent<Light>().color = red1;
                navMeshAgent.speed=6f;
            }
        }

        // Eğer hedef varsa, hedefe doğru hareket et
        if (hedef != null)
        {
            
            Vector3 hedefYonu = hedef.position - transform.position;
            hedefYonu.y = 0f; // Y eksenini ihmal etmek için

            // Düşmanın hedefe doğru dönmesi için
            Quaternion yeniRotasyon = Quaternion.LookRotation(hedefYonu);
            transform.rotation = Quaternion.Slerp(transform.rotation, yeniRotasyon, Time.deltaTime * hareketHizi);

            // Düşmanın hedefe doğru hareket etmesi için
            //transform.Translate(Vector3.forward * hareketHizi * Time.deltaTime*0.5f);
            navMeshAgent.SetDestination(hedef.transform.position);
        }
        else{
            spotlight.GetComponent<Light>().color=green;
            navMeshAgent.speed=3.5f;
        }

        // Çizgiyi ekranda sürekli göstermek için kullanılır.
        // Bu satır olmadan çizgi sadece bir frame boyunca gözükür.
        Debug.DrawRay(rayBaslangicNoktasi, rayYonu * algilamaMesafesi, Color.red);
    }

     Vector3 GetRandomPointOnNavMesh()
    {
        NavMeshHit hit;
        Vector3 randomPoint;

        // Rastgele bir nokta seç ve bu noktanın NavMesh üzerinde olup olmadığını kontrol et
        do
        {
            randomPoint = new Vector3(Random.Range(-10f, 10f), 0f, Random.Range(-10f, 10f));
        } while (!NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas));

        return hit.position;
    }
    void MoveToRandomDestination()
    {
        // Rastgele bir hedef belirle
        Vector3 randomDestination = GetRandomPointOnNavMesh();

        // Hareket et
        navMeshAgent.SetDestination(randomDestination);
    }
}
