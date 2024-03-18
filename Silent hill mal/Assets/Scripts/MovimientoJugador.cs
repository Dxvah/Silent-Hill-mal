using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public float mSpeed = 15.0f; 
    public float tSpeed = 100.0f;
    public Animator animator;
    public bool isMoving;
    public Collider puertacollider;
    public AudioSource sonidoPuerta;
    public bool isRunning = false;
    public bool isScared = false;

    void Start()
    {
        animator = GetComponent<Animator>();
       
    }

    
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * verticalInput * -mSpeed * Time.deltaTime);
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

        if(Input.GetKeyDown("space"))
        {
            puertacollider.enabled = !puertacollider.enabled;
            sonidoPuerta.Play();
        }

        if (Input.GetKeyDown("tab"))
        {
            isRunning = true;
            animator.SetBool("isRunning",isRunning);
            mSpeed = 20;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("que susto!");
            isScared = true;
            animator.SetBool("IsScared", isScared);

            isScared = false;
        }
    }

}
