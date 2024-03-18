using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    bool isPlayerinRange = false;
    public float speed = 40f;
    public Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    

    private void OnTriggerEnter(Collider collision)
    {
        //Debug.Log("inside"+ collision.gameObject.tag);
         if(collision.gameObject.CompareTag ("Player"))
        {
            isPlayerinRange = true;
            if (isPlayerinRange == true)
            {
                transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x, player.position.y, player.position.z), speed * Time.deltaTime);

                animator.SetBool("isPlayerInRange", isPlayerinRange);
            }
        }
    }

}
