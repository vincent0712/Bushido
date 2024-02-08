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
    private PlayerController playerController;


    private void Start()
    {
        playerController = GetComponentInParent<PlayerController>();
    }
    void Update()
    {

        SwordHitBox.transform.localPosition = playerController.lastDir * 1.5f; 

        /*
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
        */
        

       

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit something");
        if (collision.transform.CompareTag("Enemy"))
        {
            Debug.Log("Hit enemy");
            collision.transform.GetComponent<Health>().TakeDamage(damage);


        }
    }
}
