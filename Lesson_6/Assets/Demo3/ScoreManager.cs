using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    private int score = 0;

    public TextMeshProUGUI txtScore;

    #region Singleton

    public static ScoreManager instance;

    private void Singleton()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    #endregion

    private void Awake()
    {
        Singleton();
    }

    public void IncreaseScore()
    {
        score++;
        txtScore.text = $"Score: {score}";
    }

}
