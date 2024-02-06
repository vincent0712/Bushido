using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public PlayerController playerController;
    public GameObject Arrow;
    public Transform spawnPoint;
    //public AudioClip shootSound;
    //public AudioClip NoArrow;
    //private AudioSource audioSource;

    public int ammo = 20;
    public float shootingRate = 0.2f;
    //private float shootingTimer = 0f;

    void Start()
    {
        //audioSource = GetComponent<AudioSource>();
    }


    void Update()
    {
        // One shoot
        if (Input.GetButtonDown("Fire"))
        {
            if (ammo > 0)
            {
                // todo set rotation on bullet
                float angle = Mathf.Atan2(playerController.lastDir.y,
                    playerController.lastDir.x) * Mathf.Rad2Deg;

                Instantiate(Arrow, spawnPoint.position, Quaternion.Euler(0f, 0f, angle));
                ammo--;
                //audioSource.PlayOneShot(shootSound);
            }
            else
            {
                //audioSource.PlayOneShot(NoArrow);
            }
        }
  
 
    
    
    
    
    }

public void Addammo(int amount)
    {
        ammo += amount;
        //audioSource.PlayOneShot(NoArrow);
    }

}
