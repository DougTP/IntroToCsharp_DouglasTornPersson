using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.TextCore.Text;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerTurn playerTurn;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float rotationSpeed = 2f;
    
    void Update()
    {
        if (playerTurn.IsPlayerTurn())
        {
            // to move left or right
            if (Input.GetAxis("Horizontal") != 0)
            {
                transform.Rotate(transform.up * rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal"),
                    Space.World);
            }

            //to move forward or backward
            if (Input.GetAxis("Vertical") != 0)
            {
                transform.Translate(transform.forward * speed * Time.deltaTime * Input.GetAxis("Vertical"),
                    Space.World);
            }

            if (Input.GetKeyDown("space") && IsTouchingFloor())
            {
                Jump();
            }
        }
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * 100f);
    }

    
    private bool IsTouchingFloor() //spherecast
    {
        RaycastHit hit;
        return Physics.SphereCast(transform.position, 0.05f, -transform.up, out hit, 1f);
    }
}
