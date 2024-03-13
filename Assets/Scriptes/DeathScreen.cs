using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DeathScreen : MonoBehaviour
{
    bool GameOver;
    public GameObject Player;
    public GameObject DeathMenu;
    void Update()
    {
            
        if (Player == null)
        {
            GameOver = true;
        }
        if (GameOver == true)
        {
            DeathMenu.SetActive(true);
        }
    }
}
