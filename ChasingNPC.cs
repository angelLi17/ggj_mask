using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingNPC : MonoBehaviour
{
    public Rigidbody2D playerRB;
    Vector2 direction = Vector2.right;
    Rigidbody2D rBody;
    public float speed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();

        speed = Random.Range(2.5f, 2.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        //distance to player
        float distance = Vector2.Distance(rBody.position, playerRB.position);

        if(distance < 100f)
        {
            //direction of player
            direction = (playerRB.position - rBody.position).normalized;

            Vector2 newPos = rBody.position + (direction * speed * Time.fixedDeltaTime);
            rBody.MovePosition(newPos);
        }
    }

}
