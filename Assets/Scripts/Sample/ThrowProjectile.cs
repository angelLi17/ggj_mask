using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowProjectile : MonoBehaviour
{
    public GameObject prefabToThrow;
    Vector2 aim = Vector2.right;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        //only update aim if our player is pressing down on the horizontal or vertical
        //horizontal != 0

        if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        aim.x = Input.GetAxisRaw("Horizontal");
        aim.y = Input.GetAxisRaw("Vertical");


        // throw on button press
        //if (Input.GetKeyDown(KeyCode.Tab))   --> choose a specific key
        if (Input.GetButtonDown("Fire1"))
        {
            ThrowPrefab();
        }
    }

    void ThrowPrefab()
    {
        // add prefab to scene
        // Instantiate(prefabToThrow, transform.position, transform.rotation);  ->instantiate with position and rotation
        GameObject thrownObject = Instantiate(prefabToThrow);

        // move object to player
        thrownObject.transform.position = gameObject.transform.position;

        Projectile projectileComponent = thrownObject.GetComponent<Projectile>();
        projectileComponent.direction = aim.normalized;
    }
}
