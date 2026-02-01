using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ThirdPersonCam : MonoBehaviour
{
    [Header("References")]
    public Transform orientation;
    public Transform player;
    public Transform playerObj;
    public Rigidbody rb;

    public float rotationSpeed;

    public void Update()
    {
        //rotate orientation
        Vector3 viewDir = player position = new Vector3(transform.position.x, player position.y, player.position.z);
        orientation.forward = viewDir.normalized;

        //roate player object
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

    }
}
