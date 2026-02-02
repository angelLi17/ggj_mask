using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingNPC3D : MonoBehaviour
{
    public GameObject playerObj;      // Drag the player's Rigidbody here (3D)
    private Rigidbody rBody;

    public float speed = 3f;
    public float chaseRange = 50f;

    private void Start()
    {
        rBody = GetComponent<Rigidbody>();

        // If you want random speed, use a range (your 2D code had same min/max)
        speed = Random.Range(1.5f, 2f);
    }

    private void FixedUpdate()
    {
        if (playerObj == null) return;

        float distance = Vector3.Distance(rBody.position, playerObj.transform.position);

        if (distance < chaseRange)
        {
            Vector3 direction = (playerObj.transform.position - rBody.position).normalized;

            // If you want the enemy to stay on the ground (no flying), uncomment:
            // direction.y = 0f;
            // direction = direction.normalized;

            Vector3 newPos = rBody.position + direction * speed * Time.fixedDeltaTime;
            rBody.MovePosition(newPos);
        }
    }
}

