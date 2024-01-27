using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA;

public class papaAngle : MonoBehaviour
{
    public float algilamaMesafesi = 10f;
    public float hareketHizi = 5f;
    public Transform hedef;
    public Light spotlight;

    public Color red1, green;

    private void Start()
    {

    }

    void Update()
    {
        // Düşmanın ortasından biraz yukarıda başlayarak yukarıya doğru bir ışın oluştur
        Vector3 rayBaslangicNoktasi = transform.position + new Vector3(0f, 0.5f, 0f);
        Vector3 rayYonu = transform.forward;

        RaycastHit hit;

        if (Physics.Raycast(rayBaslangicNoktasi, rayYonu, out hit, algilamaMesafesi))
        {
            Debug.Log("Çarpışan Nesne: " + hit.collider.gameObject.name);
            // Işın bir nesneye çarptı, çarptığı nesnenin etiketini kontrol et
            if (hit.collider.CompareTag("Player"))
            {
                // Eğer çarptığı nesne oyuncu ise, hedefi güncelle
                hedef = hit.collider.transform;
                Debug.Log("Oyuncu görüldü!");
                spotlight.GetComponent<Light>().color = red1;
            }
        }

        // Eğer hedef varsa, hedefe doğru hareket et
        if (hedef != null)
        {
            //spotlight.GetComponent<Light>().color=green;
            Vector3 hedefYonu = hedef.position - transform.position;
            hedefYonu.y = 0f; // Y eksenini ihmal etmek için

            // Düşmanın hedefe doğru dönmesi için
            Quaternion yeniRotasyon = Quaternion.LookRotation(hedefYonu);
            transform.rotation = Quaternion.Slerp(transform.rotation, yeniRotasyon, Time.deltaTime * hareketHizi);

            // Düşmanın hedefe doğru hareket etmesi için
            transform.Translate(Vector3.forward * hareketHizi * Time.deltaTime*0.5f);
        }

        // Çizgiyi ekranda sürekli göstermek için kullanılır.
        // Bu satır olmadan çizgi sadece bir frame boyunca gözükür.
        Debug.DrawRay(rayBaslangicNoktasi, rayYonu * algilamaMesafesi, Color.red);
    }
}
