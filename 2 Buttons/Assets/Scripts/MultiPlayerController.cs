using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiPlayerController : GameController
{
    [SerializeField]
    GameObject playerPref;
    [SerializeField]
    GameObject player2Pref;
    [SerializeField]
    Text scoreText;
    [SerializeField]
    Text finalScoreText;
    [SerializeField]
    CollectibleSpawner collectibleSp;
    [SerializeField]
    List<Slider> sliders;

    public GameObject Looser { get; set; }
    GameObject player1;
    GameObject player2;

    private void Start()
    {
        GameMaster.instance.OnGameOver += GameOver;
    }

    private void OnDisable()
    {
        GameMaster.instance.OnGameOver -= GameOver;
    }
    protected override void Begin()
    {
        base.Begin();
        player1.GetComponent<EngineHandler>().CanMove = true;
        player2.GetComponent<EngineHandler>().CanMove = true;
        collectibleSp.Spawn();

    }

    override protected void Initialize()
    {
        base.Initialize();
        player1 = Instantiate(playerPref);
        player1.GetComponent<ScoreController>().Initialize(scoreText);
        player1.transform.position = new Vector3(-2,0,0);
        player1.GetComponent<TimerHandler>().Sliders = new List<Slider> { sliders[0] };

        player2 = Instantiate(player2Pref);
        player2.GetComponent<ScoreController>().Initialize(scoreText);
        player2.transform.position = new Vector3(2, 0, 0);
        Color newCol = player2.GetComponent<SpriteRenderer>().color;
        sliders[1].GetComponentInChildren<Image>().color = new Color(newCol.r,newCol.g,newCol.b, sliders[1].GetComponentInChildren<Image>().color.a);
        player2.GetComponent<TimerHandler>().Sliders = new List<Slider> { sliders[1] };
    }

    public override void GameOver()
    {
        base.GameOver();
        GameObject winner;
        scoreText.text = "asdf";
        if (Looser == player1)
        {
            winner = player2;
            finalScoreText.text = "P2 has won with score:";
        }
        else
        {
            winner = player1;
            finalScoreText.text = "P1 has won with score:";
        }
        // winner.GetComponent<ScoreController>().Score.ToString();
        winner.GetComponentInChildren<TrailRenderer>().transform.parent = null;
        winner.GetComponent<PlayerDeathParticlesController>().SpawnEffect();
        Destroy(winner);
    }

}
