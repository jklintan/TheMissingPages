using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyFall : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 10f;
    public GameObject player;
    bool falling = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Get the players position
        var playerPos = player.transform.position.x;
        var playerY = player.transform.position.y;

        //Get the enemys position
        var enemyPosx = rb.transform.position.x;
        var enemyPosy = rb.transform.position.y;

        //If the player is close, start falling
        if(Mathf.Abs(enemyPosx-playerPos) < 7)
        {
            falling = true;
        }

        if (falling)
        {
            rb.AddForce(new Vector2(0, -2));
        }

        //Check if hitting the player
        if ((Mathf.Abs(enemyPosx - playerPos) < 1) && (Mathf.Abs(enemyPosy - playerY) < 5 && enemyPosy > -6))
        {
            SceneManager.LoadScene(5); //Return to world of books
        }

        //Destroy itself if outside screen
        if(enemyPosy < -20)
        {
            Destroy(gameObject);
        }
    }
}
