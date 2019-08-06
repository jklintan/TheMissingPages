using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterControl : MonoBehaviour
{
    public float maxSpeed = 10f;
    bool facingRight = true;
    public static Rigidbody2D Instance;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Get horizontal movement
        float move = Input.GetAxis("Horizontal");


    }
}
