using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird : MonoBehaviour
{

    public int force = 500;
    private Rigidbody2D rb;
    private Animator anim;
    public int speed = 20;


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;


    }
    // GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;

}
