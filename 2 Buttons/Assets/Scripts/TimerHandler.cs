using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerHandler : MonoBehaviour
{
    [SerializeField]
    float maxTime=10;
    [SerializeField]
    [Range(0, 1)]
    float timeProgressAmount= 0.0125f;
    [SerializeField]
    float maxTimePenalty = 2f;

    float timePenaltyProgress = 0.05f;
    float timePenalty;
    float timeLeft; 
    List<Slider> sliders;
    bool gameStarted;
    int lvl = 0;

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
            {
                timePenaltyProgress += timeProgressAmount;
                lvl++;
                if (lvl%5 == 0)
                {
                    timePenalty = Mathf.SmoothStep(0, maxTimePenalty, timePenaltyProgress);
                }

            }
        }
    }
	// Use this for initialization
	void Start ()
    {
        timeLeft = maxTime/4;
        timePenaltyProgress = timeProgressAmount;
        timePenalty =Mathf.SmoothStep(0, maxTimePenalty, timePenaltyProgress);
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
            timeLeft -= Time.deltaTime * timePenalty;
            foreach (Slider slider in sliders)
            {
                slider.value = timeLeft;
            }
            if (timeLeft <= 0)
            {
                GetComponentInChildren<TrailRenderer>().transform.SetParent(null);
                MultiPlayerController mpc = FindObjectOfType<MultiPlayerController>();
                if (mpc != null)
                {
                    mpc.Looser = gameObject;
                }
                GameMaster.instance.GameOver();
                GetComponent<PlayerDeathParticlesController>().SpawnEffect();
                Destroy(gameObject);

            }
                
        }
    }

    private void GameStarted()
    {
        gameStarted = true;
    }

}
