using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public GameManager gameManager;
    public Text ScoreText;
    public Text WaveNumb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = gameManager.score.ToString();
        WaveNumb.text = "Wave " + gameManager.roundNum.ToString();
    }
}
