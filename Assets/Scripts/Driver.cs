using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
  [SerializeField] float steerSpeed = 0.1f;
  [SerializeField] float moveSpeed = 20f;
  [SerializeField] float slowSpeed = 15f;
  [SerializeField] float boostSpeed = 25f;
       void Start()
  {
    
  }

      void Update()
  {
      float steerAmount = Input.GetAxisRaw("Horizontal") * steerSpeed*Time.deltaTime;
      float moveAmount = Input.GetAxisRaw("Vertical")*moveSpeed*Time.deltaTime;
      
      if (moveAmount>=0)
    {
            transform.Rotate(0, 0, -steerAmount);
            transform.Translate(0, moveAmount,0);
    }

      else
    {
            transform.Rotate(0, 0, steerAmount);
            transform.Translate(0, moveAmount,0);
    }
  }
    
    void OnTriggerEnter2D(Collider2D other)
  {
      if (other.tag == "Boost")
    {
      moveSpeed = boostSpeed;
    }
    
  }
 
  void OnCollisionEnter2D(Collision2D other)
  {
      if (other.gameObject.tag == "Obstacle")
    {
      moveSpeed = slowSpeed;
    }
  }
}