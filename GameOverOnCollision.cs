using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverOnCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //go to game over
        if(collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Game Over");
        }
    }
}
