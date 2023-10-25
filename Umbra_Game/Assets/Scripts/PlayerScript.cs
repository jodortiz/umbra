using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float health;
    [SerializeField] private GameObject spawner;

    private float movementH;
    private bool isFacingRight;

    public Animator anim;
    public bool playerHiding;

    private Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        health = 1;
        body = GetComponent<Rigidbody2D>();

        playerHiding = false;
        isFacingRight = true;

    }

    // Update is called once per frame
    void Update()
    {
        //-------------movement 
            //take in horizontal input
           
        movementH = Input.GetAxis("Horizontal");

            // adjust facing direction
        if(movementH < 0 && isFacingRight)
        {
            FlipBody();
        }
        if(movementH > 0 && !isFacingRight)
        {
            FlipBody();
        }
            //move player
        body.velocity = new Vector2(movementH * speed, body.velocity.y);

            //update animation parameter for walking animation
        anim.SetFloat("Speed", Mathf.Abs(body.velocity.x));

        if (health == 0)
        {
            SceneManager.LoadScene(sceneBuildIndex:3);
        }


    }

    private void FlipBody()
    {
        Vector2 currentScale = body.transform.localScale;
        currentScale.x *= -1;
        body.transform.localScale = currentScale;

        isFacingRight = !isFacingRight;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // if the player collides with a tree, hide the player 
        if (other.gameObject.tag == "Tree")
        {
            Debug.Log("Player is Hiding");
            playerHiding = true;
        }
        // if the player collides with light and is not hiding, take away health
        if (other.gameObject.tag == "Light Hit" && !playerHiding)
        {
            ChangeHealth(-1);
            Debug.Log("HIT - 1");
            Debug.Log("Current Health: " + health);
        }
        // activate obstacle spawner when player reaches game start trigger
        if (other.gameObject.tag == "Game Start")
        {
            Debug.Log("Game Started");
            spawner.GetComponent<spawnerScript>().gameStart = true;
            Destroy(other.gameObject);
        }
        //win condition
        if (other.gameObject.tag == "Goal")
        {
            SceneManager.LoadScene(sceneBuildIndex: 4);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Tree")
        {
            Debug.Log("Not hiding");
            playerHiding = false;
        }
    }
    public void ChangeHealth(int amount)
    {
        health += amount;
    }
}
