using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{

    [SerializeField] float steerSpeed = 1f; 
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float slowSpeed = 15f;
    [SerializeField] float boostSpeed = 35f;   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    void OnCollisionEnter2D(Collision2D other){
        moveSpeed = slowSpeed;
        Debug.Log("Les obstacles me ralentissent..." + " " + moveSpeed);
    }
    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "SpeedUp"){
            moveSpeed = boostSpeed;
            Debug.Log("Est-ce que je touche le boost ?" + " " + moveSpeed);
        }
    }
}
