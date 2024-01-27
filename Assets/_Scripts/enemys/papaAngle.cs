using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class papaAngle : MonoBehaviour
{
   public float algilamaMesafesi = 10f;
    public float hareketHizi = 5f;

    public  Transform hedef;

    void Update()
    {
        // Düşmanın önünde bir ışın oluştur
        Vector3 rayYonu = transform.forward;
        RaycastHit hit;

        if (Physics.Raycast(transform.position, rayYonu, out hit, algilamaMesafesi))
        {
            // Işın bir nesneye çarptı, çarptığı nesnenin etiketini kontrol et
            if (hit.collider.CompareTag("Player"))
            {
                // Eğer çarptığı nesne oyuncu ise, hedefi güncelle
                
                hedef = hit.collider.transform;
                Debug.Log("Oyuncu görüldü!");
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
            transform.Translate(Vector3.forward * hareketHizi * Time.deltaTime);
        }

        // Çizgiyi ekranda sürekli göstermek için kullanılır.
        // Bu satır olmadan çizgi sadece bir frame boyunca gözükür.
        Debug.DrawRay(transform.position, rayYonu * algilamaMesafesi, Color.red);
    }
}
