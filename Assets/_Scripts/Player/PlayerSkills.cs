using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkills : MonoBehaviour
{
  public Image filledImage;

  public GameObject bombPrefab;
  public Transform  attach;
    public float throwForce = 10f;
    public Sprite newSprite,oldsprite;
   
    private void Start()
    {
        filledImage.sprite = oldsprite;
    }
    

    void Update()
    {
        if(filledImage.fillAmount==1f){
            filledImage.sprite = newSprite;
        }

        if (Input.GetKeyDown(KeyCode.Space) && filledImage.fillAmount==1f)
        {
            ThrowBomb();
            filledImage.fillAmount=0f;
            filledImage.sprite = oldsprite;
        }
    }

    void ThrowBomb()
    {
        GameObject bomb = Instantiate(bombPrefab,attach.position , Quaternion.identity);

        Rigidbody bombRb = bomb.GetComponent<Rigidbody>();

        bombRb.AddForce(Vector3.up * throwForce, ForceMode.Impulse);
    }
}
