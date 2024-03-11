using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyWaves : MonoBehaviour
{
    public GameObject Enemy;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Wave();
        }
    }


    void Wave()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 0)
        {
            Instantiate(Enemy, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }

}
