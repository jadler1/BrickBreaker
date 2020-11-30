using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public Ball initialBall;
	public Ball _b;

	public Paddle paddle;

	public static bool fired;
    // Start is called before the first frame update
    void Start()
    {
    	fired = false;
        StartBall();
    }

    // Update is called once per frame
    void Update()
    {
    	HandleInput();
        Vector3 paddlePos = paddle.gameObject.transform.position;
    	Vector3 ballPos = new Vector3(paddlePos.x, paddlePos.y + .3f,0);
    	if(!fired){
    		initialBall.transform.position = ballPos;
    	}
    }

    void HandleInput(){
    	if(Input.GetKey(KeyCode.Space)){
        	FireBall();
        }
    }

    void StartBall(){
    	Vector3 paddlePos = paddle.gameObject.transform.position;
    	Vector3 ballPos = new Vector3(paddlePos.x, paddlePos.y + .3f,0);
    	initialBall = Instantiate(_b, ballPos, Quaternion.identity);
    }

    void FireBall(){
    	if(!fired){
    		fired = true;
    		initialBall.Fire();
    	}

    }
}
