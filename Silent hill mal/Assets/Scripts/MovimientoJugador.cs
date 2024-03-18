using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public float mSpeed = 5.0f; 
    public float tSpeed = 100.0f;
    public Animator animator;
    public bool isMoving;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * verticalInput * mSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up * horizontalInput * tSpeed * Time.deltaTime);

        if (verticalInput != 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
        animator.SetBool("IsMoving", isMoving);
    }
}
