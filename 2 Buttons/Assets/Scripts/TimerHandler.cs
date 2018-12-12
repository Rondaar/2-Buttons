using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerHandler : MonoBehaviour
{
    [SerializeField]
    float maxTime=10;
    [SerializeField]
    float timePenaltyMultiplayer = 1.1f;
    float timeLeft; 
    List<Slider> sliders;
    bool gameStarted;

    public List<Slider> Sliders
    {
        get
        {
            return sliders;
        }
        set
        {
            sliders = value;
            foreach(Slider slider in sliders)
            {
                
                slider.maxValue = maxTime;
                slider.gameObject.SetActive(true);
            }
        }
    }

    public float Multiplayer { get; set; }

    public float TimeLeft
    {
        get
        {
            return timeLeft;
        }
        set
        {
            timeLeft = Mathf.Min(value, maxTime);
            if (value > 0)
                Multiplayer *= timePenaltyMultiplayer;
        }
    }
	// Use this for initialization
	void Start ()
    {
        Multiplayer = .25f;
        timeLeft = maxTime;
        GameMaster.instance.OnGameBegin += GameStarted;
	}

    private void OnDisable()
    {
        GameMaster.instance.OnGameBegin -= GameStarted;
    }
    // Update is called once per frame
    void Update ()
    {
        if (gameStarted)
        {
            timeLeft -= Time.deltaTime * Multiplayer;
            foreach (Slider slider in sliders)
            {
                slider.value = timeLeft;
            }
            if (timeLeft <= 0)
                Destroy(gameObject);
        }
    }

    private void GameStarted()
    {
        gameStarted = true;
    }

    private void OnDestroy()
    {
        GetComponentInChildren<TrailRenderer>().transform.SetParent(null);
        GameMaster.instance.GameOver();
    }
}
