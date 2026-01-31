using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public int health = 3;
    public GameObject loot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DealDamage(int damageAmount)
    {
        health -= damageAmount;

        if(health <= 0)
        {
            if(loot != null)
            {
                GameObject newLoot = Instantiate(loot);
                newLoot.transform.position = transform.position;
            }

            Destroy(gameObject);

        }
    }
}
