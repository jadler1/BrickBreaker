using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
	public GameObject ball;
	private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = ball.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0f,-1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // void OnCollisionEnter2D(Collision2D collision){
    // 	//rb.velocity = -1*rb.velocity;
    // }

    public void Fire(){
    	rb.AddForce(transform.up*200);
    }
}
