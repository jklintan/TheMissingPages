using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class girlMove : MonoBehaviour
{
    public static bool talkToTumnus;
    public static bool atDoorNotOpen;
    public static int count;
    public static bool narniaDone = false;

    public float speed = 5f;
    public float jumpForce = 70f;

    private Rigidbody2D rb;
    Animator anim;

    bool facingRight = true;
    bool grounded = false;
    //bool doubleJump = false;
    bool atWardrobe = false;
    bool atWardrobe2 = false;
    bool atInfoChar = false;
    bool jumpAnimPlayed = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    private float wardrobePos;
    private float wardrobePos2;
    private float wardrobePos3;
    private float wardrobePos4;
    private float infoCharPos1;
    private float library;
    private Vector3 page2;
    private Vector3 page1;
    private Vector3 page3;
    bool stand = false;
    bool inJump = false;
    int id;
    bool found1 = false;
    bool found2 = false;
    bool found3 = false;

    public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        //Set static variables at start
        talkToTumnus = false;
        atDoorNotOpen = false;
        count = 0;

        //Get active scene ID
        id = SceneManager.GetActiveScene().buildIndex;

        //Get rigidbody component
        rb = GetComponent<Rigidbody2D>();

        //Get the animator
        anim = GetComponent<Animator>();

        //Find the doors in the scene
        wardrobePos = GameObject.Find("wardrobe").transform.position.x;
        wardrobePos2 = GameObject.Find("wardrobe2").transform.position.x;
        //wardrobePos3 = GameObject.Find("wardrobe3").transform.position.x;
        //wardrobePos4 = GameObject.Find("wardrobe4").transform.position.x;

        //Find the info characters
        infoCharPos1 = GameObject.Find("infoChar1").transform.position.x;

        //Find library position
        library = GameObject.Find("FabulasLibrary").transform.position.x;

        //Find the pages
        page1 = GameObject.Find("page1").transform.position;
        page2 = GameObject.Find("page2").transform.position;
        page3 = GameObject.Find("page3").transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Check if grounded and send to animator controller
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("ground", grounded);

        if (grounded)
            //doubleJump = false;

            //Enable / disable the players ability to steer when jumping
            if (!grounded)
                return;

        //Horizontal movement
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y);
        anim.SetFloat("speed", Mathf.Abs(move)); //Send speed to animator controller

        //Vertical movement
        anim.SetFloat("vspeed", rb.velocity.y);

        //Flipping the character if we are changing direction
        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();

        //If character is at a wardrobe
        if ((Mathf.Abs(rb.transform.position.x - wardrobePos) < 0.5))
        {
            atWardrobe = true;
        }
        else
        {
            atWardrobe = false;
        }

        //If character is at a wardrobe
        if ((Mathf.Abs(rb.transform.position.x - wardrobePos2) < 0.5))
        {
            atWardrobe2 = true;
        }
        else
        {
            atWardrobe2 = false;
        }

        //If character is at info character
        if ((Mathf.Abs(rb.transform.position.x - infoCharPos1) < 0.5))
        {
            atInfoChar = true;
        }
        else
        {
            atInfoChar = false;
        }

        //If the character is at either one of the sides, display conversation "can't go further"
        //Only appears if we are in resting area
        if ((rb.transform.position.x < -50 || rb.transform.position.x > 90) && SceneManager.GetActiveScene().buildIndex == 5)
        {
            //print("This part of the world of books can't be discovered yet...");
        }

        //Not yet implemented worlds
        if ((Mathf.Abs(rb.transform.position.x - wardrobePos2) < 0.5) || (Mathf.Abs(rb.transform.position.x - wardrobePos3) < 0.5) || (Mathf.Abs(rb.transform.position.x - wardrobePos4) < 0.5))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //print("You can't enter into this world yet...");
            }
        }

        //Finding of first page
        if ((Mathf.Abs(rb.transform.position.x - page1.x) < 0.8) && (Mathf.Abs(rb.transform.position.y - page1.y) < 1.2) && !found1)
        {
            count += 1;
            GameObject.Find("page1").SetActive(false);
            //print(count);
            found1 = true;
        }

        //Finding of second page
        if ((Mathf.Abs(rb.transform.position.x - page2.x) < 0.8) && (Mathf.Abs(rb.transform.position.y - page2.y) < 1.2) && !found2)
        {
            count += 1;
            GameObject.Find("page2").SetActive(false);
            //print(count);
            found2 = true;
        }

        //Finding of third page
        if ((Mathf.Abs(rb.transform.position.x - page3.x) < 0.8) && (Mathf.Abs(rb.transform.position.y - page3.y) < 1.2) && !found3)
        {
            count += 1;
            GameObject.Find("page3").SetActive(false);
            //print(count);
            found3 = true;
        }

        if (count == 3)
            narniaDone = true;

        //End of Narnia
        if (rb.position.x > 291 && SceneManager.GetActiveScene().buildIndex == 6)
        {
            if (count == 3)
            {
                narniaDone = true;
            }

            SceneManager.LoadScene(5);
        }

        //Display library
        if(Mathf.Abs(rb.position.x - library) < 1 && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(7);
        }
    }

    void Update()
    {
        //Play running animation
        if (rb.velocity.x != 0 && grounded)
        {
            anim.Play("run");
        }

        //Play standing still animation
        if (rb.velocity.x == 0 && grounded)
        {
            anim.Play("still");
        }

        //Play jumping animation
        if (!grounded)
        {
            anim.Play("jump");
        }

        //Jump controller, only jump when grounded
        if ((grounded) && Input.GetKeyDown(KeyCode.UpArrow))
        {
            anim.SetBool("ground", false);
            rb.AddForce(new Vector2(0, jumpForce * 4));

            //if (!doubleJump && !grounded)
            //    doubleJump = true;
        }

        //If the player is at a wardrobe, you can enter
        if (atWardrobe && Input.GetKeyDown(KeyCode.Space))
        {
            //print("Enter into world");
            SceneManager.LoadScene(6);
        }

        //If the player is at a info character, you can interact with it
        if (atInfoChar && Input.GetKeyDown(KeyCode.Space))
        {
            talkToTumnus = true;
            panelHandle.convoOpen = true;
        }

        //If the player is at a door 2
        if (atWardrobe2 && Input.GetKeyDown(KeyCode.Space))
        {
            atDoorNotOpen = true;
            panelHandle.notOpen = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !panelHandle.firstInfoDisplayed && id == 5)
        {
            ////Play next sentence
            if (panelHandle.countUserInteract < 1)
            {
                panelHandle.countUserInteract++;
            }

            if (panelHandle.countUserInteract == 1)
            {
                //panelHandle.hidePanel();
                panelHandle.firstInfoDisplayed = true;
            }
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }



    //OnTriggerEnter2D is called whenever this object overlaps with a trigger collider.
    void OnTriggerEnter2D(Collider2D other)
    {
        //Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
        if (other.gameObject.CompareTag("page"))
        {
            //... then set the other object we just collided with to inactive.
            other.gameObject.SetActive(false);
        }

        //Add one to the current value of our count variable.
        count = count + 1;

        //Update the currently displayed count by calling the SetCountText function.
        //SetCountText();
    }

}
