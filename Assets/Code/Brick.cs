using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
	public Sprite blue;
	public Sprite red;
	public Sprite green;

	public SpriteRenderer sr;

	//set the HP in the unity editor
	public int hp;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hp > 3){
        	hp = 3;
        }
        if(hp == 3){
        	sr.sprite = red;
        }
        else if (hp ==2){
        	sr.sprite = green;
        }
        else if (hp == 1){
        	sr.sprite = blue;
        }
        else{
        	Destroy(gameObject);
        }
    }


    void OnCollisionEnter2D(Collision2D collision){
    	if(collision.gameObject.tag == "Ball"){
    		ProcessHit();
    	}
    }

    void ProcessHit(){
    	//Right now this just lowers the hp, it could be modified to allow powerups to drop
    	hp--;
    	GameManager.AddScore(1);
    }
}
