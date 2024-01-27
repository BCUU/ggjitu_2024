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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ThrowBomb();
        }
    }

    void ThrowBomb()
    {
        GameObject bomb = Instantiate(bombPrefab,attach.position , Quaternion.identity);

        Rigidbody bombRb = bomb.GetComponent<Rigidbody>();

        bombRb.AddForce(Vector3.up * throwForce, ForceMode.Impulse);
    }
}
