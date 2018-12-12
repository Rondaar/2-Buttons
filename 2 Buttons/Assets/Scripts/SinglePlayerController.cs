using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SinglePlayerController : GameController
{

    [SerializeField]
    GameObject playerPref;
    [SerializeField]
    Text scoreText;
    [SerializeField]
    CollectibleSpawner collectibleSp;
    [SerializeField]
    List<Slider> sliders;

    GameObject player;

    protected override void Begin()
    {
        base.Begin();
        player.GetComponent<EngineHandler>().CanMove = true;
        collectibleSp.Spawn();
        
    }

    override protected void Initialize()
    {
        base.Initialize();
        player = Instantiate(playerPref);
        player.GetComponent<ScoreController>().Initialize(scoreText);
        player.transform.position = Vector3.zero;
        player.GetComponent<TimerHandler>().Sliders = sliders;
    }

    public override void GameOver()
    {
        base.GameOver();
    }

}
