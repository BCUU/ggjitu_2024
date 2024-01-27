using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEffect : MonoBehaviour
{
    public float explosionForce = 10f;
    public float explosionRadius = 5f;
    public float targetExplosionRadius = 10f;
    private SphereCollider sphereCollider;
    private Rigidbody rb;
    public float delay;
    public bool isWait=false;
    void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();
        rb= GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground")||collision.gameObject.CompareTag("Enemys")){
            StartCoroutine(waitForBouncy(delay));
            if(isWait){
                Rigidbody otherRb = collision.gameObject.GetComponent<Rigidbody>();
                
                if (otherRb != null)
                {
                    Vector3 explosionDirection = collision.transform.position - transform.position;
                    float distance = explosionDirection.magnitude;

                    float relativeDistance = (explosionRadius - distance) / explosionRadius;
                    float force = relativeDistance * explosionForce;

                    otherRb.AddForce(explosionDirection.normalized * force, ForceMode.Impulse);
                } 
            } 
        }
        else{
             StartCoroutine(waitForDestroy());
        }
    }

    IEnumerator waitForBouncy(float delay){
         yield return new WaitForSeconds(delay);
         sphereCollider.radius = targetExplosionRadius;
         isWait=true;
         Vector3 hareket = transform.forward  * Time.deltaTime;
        rb.MovePosition(rb.position + hareket);
         StartCoroutine(waitForDestroy());
    }
     IEnumerator waitForDestroy(){
         yield return new WaitForSeconds(5f);
         Destroy(gameObject);
         
    }
}
