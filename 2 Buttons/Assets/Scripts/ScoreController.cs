using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

    Text scoreText;
    [SerializeField]
    Vector3 offset;

    Animator scoreAnim;

    private int score;

    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            scoreText.transform.position = Camera.main.WorldToScreenPoint(transform.position+offset);
            scoreAnim.SetTrigger("tick");
            score = value;
            scoreText.text = score.ToString();
        }
    }

    private void Start()
    {
        GameMaster.instance.OnGameOver += AddPoints;
    }

    private void OnDisable()
    {
        GameMaster.instance.OnGameOver -= AddPoints;
    }

    void AddPoints()
    {
        GameData.Credits += score / 10;
    }
    public void Initialize(Text scoreText)
    {
        this.scoreText = scoreText;
        score = 0;
        scoreAnim = scoreText.gameObject.GetComponent<Animator>();
    }

    private void OnDestroy()
    {
        Destroy(scoreAnim);
        if (scoreText != null) {    
            scoreText.text = score.ToString();
            scoreText.GetComponent<FadeAnimationText>().StartAnimation();
            scoreText.GetComponent<ChangePosAndScaleAnimation>().StartAnimation();
        }
    }
}
