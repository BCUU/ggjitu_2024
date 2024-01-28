using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class papaManager : MonoBehaviour
{
    public float speed = 5f;
    public float xRadius = 5f;
    public float yRadius = 3f;
    public float lookInterval = 2f; 
    public float lookDuration = 1f; 
    public float lookSpeed = 2f; 
    public float centeringSpeed = 2f; 
    public Transform centerObject; 

    private Rigidbody rb;
    private float angle = 0f;
    private bool isMoving = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (centerObject == null)
        {
            centerObject = transform;
        }

        StartCoroutine(MoveAndLook());
    }

    void Update()
    {
        if (isMoving)
        {
            float x = xRadius * Mathf.Cos(angle);
            float z = yRadius * Mathf.Sin(angle);

            // Yeni konumu ata
            Vector3 targetPosition = centerObject.position + new Vector3(x, 0f, z);
            rb.MovePosition(targetPosition);

            transform.LookAt(new Vector3(centerObject.transform.position.x, transform.position.y, centerObject.transform.position.z));

            // Açıyı arttır
            angle += speed * Time.deltaTime;

            // Açı sınırlarını kontrol et (0-360 derece aralığında)
            if (angle > 360f)
            {
                angle -= 360f;
            }
        }
    }

    IEnumerator MoveAndLook()
    {
        while (true)
        {
            // Hareket et
            isMoving = true;

            // Durma süresi boyunca hareket et
            yield return new WaitForSeconds(lookDuration);
            xRadius = Random.Range(1f, 10f);  // You can adjust the range based on your needs
            yRadius = Random.Range(1f, 10f);

            // Dur ve rastgele bir yöne yavaşça bak
            isMoving = false;
            Vector3 randomDirection = Random.onUnitSphere;
            randomDirection.y = 0; // Y ekseninde bakmasını engelle
            Quaternion targetRotation = Quaternion.LookRotation(randomDirection, Vector3.up);

            while (Quaternion.Angle(rb.rotation, targetRotation) > 0.1f)
            {
                rb.rotation = Quaternion.Slerp(rb.rotation, targetRotation, lookSpeed * Time.deltaTime);
                yield return null;
            }

            // Etrafa bakma süresi
            yield return new WaitForSeconds(lookDuration);

            // Merkeze odaklan
            Quaternion centerRotation = Quaternion.LookRotation(centerObject.position - transform.position, Vector3.up);
            while (Quaternion.Angle(rb.rotation, centerRotation) > 0.1f)
            {
                rb.rotation = Quaternion.Slerp(rb.rotation, centerRotation, centeringSpeed * Time.deltaTime);
                yield return null;
            }

            // Tekrar harekete geç
            isMoving = true;

            // Bekleme süresi
            yield return new WaitForSeconds(lookInterval);
        }
    }
}
