using UnityEngine;
using System.Collections;

public class GameMenu : MonoBehaviour
{

    public static GameMenu _instance;
    public GUIText nowScore;
    public GUIText highScore;
    public GUITexture startTexture;

    void Awake()
    {
        _instance = this;
        this.gameObject.SetActive(false);
    }

    public  void UpdateScore(float nowScore)
    {
        float highScore= PlayerPrefs.GetFloat("score",0);

        if (nowScore > highScore)
        {
            highScore = nowScore;
        }

        PlayerPrefs.SetFloat("score", highScore);

        this.nowScore.text = nowScore+"";
        this.highScore.text = highScore + "";

        if (Input.GetMouseButtonDown(0) && GameManager._intance.GameState==GameManager.GAMESTATE_END)
        {
            Rect rect = startTexture.GetScreenRect();
            Vector3 mousePos = Input.mousePosition;
            if (mousePos.x > rect.x &&
                mousePos.x < (rect.x + rect.width) &&
                mousePos.y > rect.y &&
                mousePos.y < (rect.y + rect.width))
            {
                Application.LoadLevel(0);
            }
        }
    }
}
