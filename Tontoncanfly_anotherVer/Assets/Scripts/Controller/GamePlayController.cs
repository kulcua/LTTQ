using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlayController : MonoBehaviour {

    public static GamePlayController instance;

    [SerializeField]
    private Button instructionButton;

    [SerializeField]
    private Text scoreText, endScoreText, bestScoreText;

    [SerializeField]
    private GameObject gameOverPanel;

	public Text moneyText;
	
	int isRifleSold;
	//public GameObject rifle;
	//void Start()
	//{
	//    SoundManager.playSound("BG");
	//}
	private void Start()
	{
		//playerscripts.coinsNumber = PlayerPrefs.GetInt("Money");
		//rifle.SetActive(false);

		PlayerPrefs.SetInt("Money", playerscripts.coinsNumber);
	}
	void Awake()
    {
        Time.timeScale = 0;
        _MakeInstance();
    }

    void _MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void _SetScore(int score)
    {
        scoreText.text = "" + ScoreScript.scorevalue;
    }

    public void _InstructionButton()
    {
        Time.timeScale = 1;
        instructionButton.gameObject.SetActive(false);
    }


    public void _TonDiedShowPanel(int score)
    {
        gameOverPanel.SetActive(true);
        endScoreText.text = "" + score;
        if (score > Manager.instance.GetHighScore()) 
        {
            Manager.instance.SetHighScore(score);
        }
        bestScoreText.text = "" + Manager.instance.GetHighScore();
		//moneyText.text = playerscripts.coinsNumber.ToString();
	}



	void Update()
	{		
	}
}
