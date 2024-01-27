using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float hareketHizi = 5f;
    public float rotateHizi = 180f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        HareketKontrol();
        RotateKontrol();
    }

    void HareketKontrol()
    {
        float ileriGeri = Input.GetAxis("Vertical");
        Vector3 hareket = transform.forward * ileriGeri * hareketHizi * Time.deltaTime;
        rb.MovePosition(rb.position + hareket);
    }

    void RotateKontrol()
    {
        float yon = Input.GetAxis("Horizontal");
        float rotateMiktar = yon * rotateHizi * Time.deltaTime;
        Quaternion rotate = Quaternion.Euler(0f, rotateMiktar, 0f);
        rb.MoveRotation(rb.rotation * rotate);
    }
}
