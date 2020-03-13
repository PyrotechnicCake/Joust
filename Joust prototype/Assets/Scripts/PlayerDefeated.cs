using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDefeated : MonoBehaviour
{
    public GameObject explodeEffect;
    List<Collider> colliders = new List<Collider>();
    public GameManager gameManager;
    public int playerLives = 3;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Enemy")
        {
            if (this.gameObject.transform.position.y + 0.1f < collision.transform.position.y)
            {
                gameManager.score -= 100;
                Instantiate(explodeEffect, transform.position, Quaternion.identity);
                transform.position = GameObject.FindGameObjectWithTag("Respawn").transform.position;
                playerLives -= 1;
            }
            print("collision");
        }
        if (playerLives == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }// Start is called before the first frame update
    
}
