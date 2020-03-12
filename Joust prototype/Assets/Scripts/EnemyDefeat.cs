using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDefeat : MonoBehaviour
{
    public GameObject explodeEffect;
    List<Collider> colliders = new List<Collider>();
    public GameManager gameManager;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Player")
        {
            if (this.gameObject.transform.position.y + 0.1f < GameObject.FindGameObjectWithTag("Player").transform.position.y)
            {
                gameManager.score += 100;
                gameManager.EnemyHasDied();
                Instantiate(explodeEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);

            }
            print("collision");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    

    // Update is called once per frame
    void Update()
    {

    }
}
