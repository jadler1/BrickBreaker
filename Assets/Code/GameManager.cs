using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public Ball initialBall;
	public Ball _b;

	public Paddle paddle;

	public static bool fired;
	public Text score;
	public static int scoreNum;
	public GameObject[] bricks;

	public static bool stopGame;
	private bool endHandled;
	private bool won;

    // Start is called before the first frame update
    void Start()
    {
    	won = false;
    	stopGame = false;
    	fired = false;
    	endHandled = false;
    	scoreNum = 0;
        StartBall();
    }

    // Update is called once per frame
    void Update()
    {
    	if(!stopGame){
	    	HandleInput();
	    	BallFollow();
	    	DisplayScore();
	    	CheckOffScreen();
	    	CheckWin();
		}
		else{
			HandleEnd();
		}
    }

    void HandleEnd(){
    	if(!endHandled){
	    	GameObject.Destroy(initialBall.gameObject);
	    	GameObject.Destroy(paddle.gameObject);
	    	for(int i = 0; i < bricks.Length; i++){
	    		GameObject.Destroy(bricks[i].gameObject);
	    	}
	    	endHandled = true;
	    }
	    score.fontSize = 90;
	    if(won)
	    {
	    	score.text = "You Won! Final Score: " + scoreNum;
	    }
	    else
	    {
	    	score.text = "You Lost! Final Score: " + scoreNum;
	    }

    }

    //checks if any bricks remain
    void CheckWin(){
    	bricks = GameObject.FindGameObjectsWithTag("Brick");
    	if(bricks.Length == 0){
    		stopGame = true;
    		won = true;
    	}

    }

    //checks if the ball is off screen
    void CheckOffScreen(){
    	if(initialBall.transform.position.y < -5){
    		stopGame=true;
    	}
    }

    //shows the score on the screen
    void DisplayScore(){
    	score.text = scoreNum + "";
    }

    //keeps the ball following the paddle
    void BallFollow(){
    	if(!fired){
    		Vector3 paddlePos = paddle.gameObject.transform.position;
    		Vector3 ballPos = new Vector3(paddlePos.x, paddlePos.y + .3f,0);
    		initialBall.transform.position = ballPos;
    	}
    }

    //handles overall gameplay input
    void HandleInput(){
    	if(Input.GetKey(KeyCode.Space)){
        	FireBall();
        }
    }

    //instatiates the ball just above the center of the paddle
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

    public static void AddScore(int amt){
    	scoreNum += amt;
    }

}
