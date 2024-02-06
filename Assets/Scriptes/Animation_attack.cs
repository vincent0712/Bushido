using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Animator animator;
    

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
 

        if (Input.GetKeyDown(KeyCode.Mouse0)) // Assuming left mouse button is used for attack
        {

            animator.SetBool("isAttacking", true);

        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
       
    }


}