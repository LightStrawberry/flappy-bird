using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    //define the state of the game
    public static int GAMESTATE_MENU = 0;    //游戏菜单状态
    public static int GAMESTATE_PLAYING = 1; //游戏中状态。。。
    public static int GAMESTATE_END = 2;     //游戏结束状态

    public Transform firstBg;
    public int score=0;
    public int GameState=GAMESTATE_MENU;

    public static GameManager _intance;
	public bool haveJiaSu1=false;
	public bool haveJiaSu2=false;

    private GameObject bird;

    void Awake()
    {
        _intance = this;
        bird = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (GameState ==GameManager.GAMESTATE_MENU)
        {
            if (Input.GetMouseButtonDown(0))
            { 
                 //transform state
                GameState = GAMESTATE_PLAYING;
                //set bird is playing 
                //1.set grivaty   2.add velocity of x
                bird.SendMessage("getLife");
            }
        }

		if (score > 5) {
			if(haveJiaSu1==false){
			//加速 让速度+1
				bird.SendMessage("speedUp");
			haveJiaSu1=true;
			}
		}

		if (score > 10) {
			if(haveJiaSu2==false){
				//加速 让速度+1
				bird.SendMessage("speedUp");
				haveJiaSu2=true;
			}
		}

        if (GameState == GameManager.GAMESTATE_END)
        {
            GameMenu._instance.gameObject.SetActive(true);
            GameMenu._instance.UpdateScore(score);
        }
    }
}
