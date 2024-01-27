using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeCam : MonoBehaviour
{
   private ObjectsFader _fader;

   void Update(){
    GameObject player = GameObject.FindGameObjectWithTag("Player");
    if(player !=null){
        Vector3 dir = player.transform.position-transform.position;
        Ray ray=new  Ray(transform.position,dir);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit )){
            if(hit.collider==null){
                return;
            }
            
            if(hit.collider.gameObject==player){
                Debug.Log("player degdi");
                if(_fader!=null){
                    _fader.doFade=false;
                }
            }
            else{
                _fader=hit.collider.gameObject.GetComponent<ObjectsFader>();
                if(_fader!=null){
                    _fader.doFade=true;
                }
            }
        }
    }
   }
}
