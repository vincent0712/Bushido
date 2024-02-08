using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class dragonBoss : MonoBehaviour
{
    public int hp;
    public int attackDmg;
    [HideInInspector] public bool isDead = false;
    public UnityEvent onTakeDamage;
    public UnityEvent onDeath;
}
