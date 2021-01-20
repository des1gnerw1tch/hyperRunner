using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  public float speed;
  public float jumpPower;
  private bool touchingGround;
  [SerializeField] private Rigidbody2D rb;

  void Update()
  {
    transform.position = new Vector3 (transform.position.x + speed*Time.deltaTime, transform.position.y, transform.position.z);
    if (Input.GetKeyDown("space") && touchingGround)
        {
            Jump();
        }

    if (Input.touchCount > 0) {
      Touch touch = Input.GetTouch(0);
      if (touch.phase == TouchPhase.Began && touchingGround)  {
        Jump();
      }
    }

  }

  void Jump() {
    rb.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
    Debug.Log("Jumped");
  }

  void OnCollisionEnter2D(Collision2D other)  {
    if (other.gameObject.CompareTag("Ground")) {
      touchingGround = true;
      Debug.Log("Touched the ground");
    }
  }

  void OnCollisionExit2D(Collision2D other) {
    if (other.gameObject.CompareTag("Ground")) {
      touchingGround = false;
    }
  }



}
