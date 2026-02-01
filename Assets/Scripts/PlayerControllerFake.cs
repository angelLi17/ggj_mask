using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{
    public Animator playerAnim;
    public Rigidbody playerRigid;
    public float w_speed, wb_speed, olw_speed, rn_speed, ro_speed;
    public bool walking;
    public Transform playerTrans;

    void FixedUpdate()
    {
        // FIX 1: Removed * Time.deltaTime. Physics engines handle this automatically in FixedUpdate.
        if (Keyboard.current.wKey.isPressed)
        {
            playerRigid.linearVelocity = transform.forward * w_speed;
        }
        else if (Keyboard.current.sKey.isPressed) // Use else-if so they don't fight
        {
            playerRigid.linearVelocity = -transform.forward * wb_speed;
        }
        else
        {
            // FIX 2: Stop the velocity when no keys are pressed so the player doesn't slide
            playerRigid.linearVelocity = Vector3.zero;
        }
    }

    void Update()
    {
        // Rotation (Update is fine for rotation, but keep it consistent)
        if (Keyboard.current.aKey.isPressed)
        {
            playerTrans.Rotate(0, -ro_speed * Time.deltaTime, 0);
        }
        if (Keyboard.current.dKey.isPressed)
        {
            playerTrans.Rotate(0, ro_speed * Time.deltaTime, 0);
        }

        // --- ANIMATION LOGIC ---
        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            playerAnim.SetTrigger("walk");
            playerAnim.ResetTrigger("idle");
            walking = true;
        }
        if (Keyboard.current.wKey.wasReleasedThisFrame)
        {
            playerAnim.ResetTrigger("walk");
            playerAnim.SetTrigger("idle");
            walking = false;
        }

        if (Keyboard.current.sKey.wasPressedThisFrame)
        {
            playerAnim.SetTrigger("walkback");
            playerAnim.ResetTrigger("idle");
        }
        if (Keyboard.current.sKey.wasReleasedThisFrame)
        {
            playerAnim.ResetTrigger("walkback");
            playerAnim.SetTrigger("idle");
        }

        // --- SPRINT LOGIC ---
        if (walking)
        {
            if (Keyboard.current.leftShiftKey.wasPressedThisFrame)
            {
                w_speed = olw_speed + rn_speed; // Use olw_speed as base
                playerAnim.SetTrigger("run");
                playerAnim.ResetTrigger("walk");
            }
            if (Keyboard.current.leftShiftKey.wasReleasedThisFrame)
            {
                w_speed = olw_speed;
                playerAnim.ResetTrigger("run");
                playerAnim.SetTrigger("walk");
            }
        }
    }
}
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.InputSystem;

//public class player : MonoBehaviour
//{
//    public Animator playerAnim;
//    public Rigidbody playerRigid;
//    public float w_speed, wb_speed, olw_speed, rn_speed, ro_speed;
//    public bool walking;
//    public Transform playerTrans;


//    void FixedUpdate()
//    {
//        if (Keyboard.current.wKey.isPressed)
//        {
//            playerRigid.linearVelocity = transform.forward * w_speed * Time.deltaTime;
//        }
//        if (Keyboard.current.sKey.isPressed)
//        {
//            playerRigid.linearVelocity = -transform.forward * wb_speed * Time.deltaTime;
//        }
//    }
//    void Update()
//    {
//        if (Keyboard.current.wKey.wasPressedThisFrame)
//        {
//            playerAnim.SetTrigger("walk");
//            playerAnim.ResetTrigger("idle");
//            walking = true;
//            //steps1.SetActive(true);
//        }
//        if (Keyboard.current.wKey.wasReleasedThisFrame)
//        {
//            playerAnim.ResetTrigger("walk");
//            playerAnim.SetTrigger("idle");
//            walking = false;
//            //steps1.SetActive(false);
//        }
//        if (Keyboard.current.sKey.wasPressedThisFrame)
//        {
//            playerAnim.SetTrigger("walkback");
//            playerAnim.ResetTrigger("idle");
//            //steps1.SetActive(true);
//        }
//        if (Keyboard.current.sKey.wasReleasedThisFrame)
//        {
//            playerAnim.ResetTrigger("walkback");
//            playerAnim.SetTrigger("idle");
//            //steps1.SetActive(false);
//        }
//        if (Keyboard.current.aKey.isPressed)
//        {
//            playerTrans.Rotate(0, -ro_speed * Time.deltaTime, 0);
//        }
//        if (Keyboard.current.dKey.isPressed)
//        {
//            playerTrans.Rotate(0, ro_speed * Time.deltaTime, 0);
//        }
//        if (walking == true)
//        {
//            if (Keyboard.current.leftShiftKey.wasPressedThisFrame)
//            {
//                //steps1.SetActive(false);
//                //steps2.SetActive(true);
//                w_speed = w_speed + rn_speed;
//                playerAnim.SetTrigger("run");
//                playerAnim.ResetTrigger("walk");
//            }
//            if (Keyboard.current.leftShiftKey.wasReleasedThisFrame)
//            {
//                //steps1.SetActive(true);
//                //steps2.SetActive(false);
//                w_speed = olw_speed;
//                playerAnim.ResetTrigger("run");
//                playerAnim.SetTrigger("walk");
//            }
//        }
//    }
//}

