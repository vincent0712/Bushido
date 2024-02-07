using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class MeleeAttack : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject SwordHitBox;
    public int damage;
    public Health health;
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.D))
        {
            SwordHitBox.transform.localPosition = new Vector3(1.15f, -0.01f, 0f);
            
 

        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            SwordHitBox.transform.localPosition = new Vector3(-0.06f, 1.08f, 0f);
            

        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            SwordHitBox.transform.localPosition = new Vector3(-0.94f, 0.01f, 0f);

            
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            SwordHitBox.transform.localPosition = new Vector3(-0.07f, -1.27f, 0f);
            

        }

        

       

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            

        }
    }
}
