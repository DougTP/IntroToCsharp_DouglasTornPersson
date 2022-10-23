using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelchairAnimations : MonoBehaviour
{
    [SerializeField] private Animator anim;

    
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetTrigger("MoveForward");
        }
        else if (Input.GetKey(KeyCode.S))
        {
            anim.SetTrigger("MoveBackward");
        }
    }
}
