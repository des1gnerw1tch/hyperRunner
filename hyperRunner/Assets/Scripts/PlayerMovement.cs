using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  public float speed;
  public float jumpPower;

  private bool touchingGround;
  private int jumpsLeft;
  [SerializeField] private Rigidbody2D rb;
  [SerializeField] private Animator animator;

  void Update()
  {
    transform.position = new Vector3 (transform.position.x + speed*Time.deltaTime, transform.position.y, transform.position.z);
    if (Input.GetKeyDown("space") && jumpsLeft > 0)
        {
            Jump();
        }
//for mobile players

    /*if (Input.touchCount > 0) {
      Touch touch = Input.GetTouch(0);
      if (touch.phase == TouchPhase.Began && touchingGround)  {
        Jump();
      }
    }*/

  }

  void Jump() {
    rb.velocity =  new Vector2(rb.velocity.x, 0);;
    rb.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
    jumpsLeft-= 1;
    Debug.Log("Jumped");

    //this will double jump, happens when jumping and not touching ground
    if (!touchingGround)  {
      animator.SetTrigger("doubleJump");
    }

  }

  void OnCollisionEnter2D(Collision2D other)  {
    if (other.gameObject.CompareTag("Ground")) {
      touchingGround = true;
      jumpsLeft = 2;
      Debug.Log("Touched the ground");
      animator.SetBool("jumping", false);
    }
  }

  void OnCollisionExit2D(Collision2D other) {
    if (other.gameObject.CompareTag("Ground")) {
      touchingGround = false;
      animator.SetBool("jumping", true);
    }
  }



}
