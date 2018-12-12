using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    #region singleton
    public static GameMaster instance;

    #endregion

    [SerializeField]
    GameObject leftOption;
    [SerializeField]
    GameObject rightOption;
    [SerializeField]
    SinglePlayerController sp;
    [SerializeField]
    MultiPlayerController mp;

    public float ScreenOffset { get; set; }

    enum GameState { ChoosingGamemode, Playing, GameOver,Restart }
    GameState currState = GameState.ChoosingGamemode;

    private void Awake()
    {
        instance = this;
        ScreenOffset = 0.025f;
    }

    void Start ()
    {
        ScreenOffset = 0.025f;
        leftOption.GetComponent<SlideInAnimation>().StartAnimation();
        rightOption.GetComponent<SlideInAnimation>().StartAnimation();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (currState == GameState.ChoosingGamemode)
        {
            ChooseGameMode();
        }else if (currState == GameState.Restart)
        {
            CheckForRestartGame();
        }
	}
    
    void CheckForRestartGame()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void ChooseGameMode()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            leftOption.GetComponent<ChooseAnimation>().StartAnimation();
            sp.GetComponent<Option>().Action();
            rightOption.GetComponent<FadeAnimation>().StartAnimation();  
            Destroy(mp.gameObject);
            currState = GameState.Playing;
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            rightOption.GetComponent<ChooseAnimation>().StartAnimation();
            mp.GetComponent<Option>().Action();
            leftOption.GetComponent<FadeAnimation>().StartAnimation();
            Destroy(sp.gameObject);
            currState = GameState.Playing;
        }
    }

    public event System.Action OnGameOver;
    public event System.Action OnGameBegin;

    public void GameBegin()
    {
        OnGameBegin();
    }

    public void GameOver()
    {
        if (OnGameOver != null) OnGameOver();
        currState = GameState.GameOver;
    }
    public void InitRestart()
    {
        currState = GameState.Restart;
    }

}
