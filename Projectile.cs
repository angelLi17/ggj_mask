using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rBody;
    public Vector2 direction = Vector2.right; //new Vector2(1f, 0f)
    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 newPosition = rBody.position + direction * speed * Time.fixedDeltaTime;
        rBody.MovePosition(newPosition);

        float angle = Mathf.Atan2(direction.y, direction.x)*Mathf.Rad2Deg;
        rBody.rotation = angle;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // check that its not the player itself
        if(collision.gameObject.tag != "Player")
        {
            Destructible destructibleObject = collision.gameObject.GetComponent<Destructible>();

            if(destructibleObject != null)
            {
                destructibleObject.DealDamage(1);
            }

            Destroy(gameObject);
        }
    }
}
