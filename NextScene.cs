using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //go to game over
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Level2");
        }
    }
}
