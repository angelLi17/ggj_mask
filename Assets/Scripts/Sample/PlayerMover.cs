using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    Rigidbody2D rBody;
    Vector2 inputDirection; //(float, float) -> (player position x, y)
    public float speed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        rBody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //(1,1) + (0,1) = (1,2)
        inputDirection.x = Input.GetAxis("Horizontal");
        inputDirection.y = Input.GetAxis("Vertical");

    }

    private void FixedUpdate()
    {
        Vector2 newPosition = rBody.position + inputDirection * speed * Time.fixedDeltaTime;

        rBody.MovePosition(newPosition);
    }
}
