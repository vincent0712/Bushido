//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Waves : MonoBehaviour
{
    
    public GameObject Enemy;
    public GameObject Player;
    public float Radius = 1;
    
    private void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 0)
        {
            Wave();
            
        }
    }

    
    void Wave()
    {
        
        for (int i = 0; i < 20; i++)
        {

            Vector3 randomPos = Random.insideUnitCircle * Radius;

            Instantiate(Enemy, randomPos, Quaternion.identity);
            
        }
       

    }
   

}