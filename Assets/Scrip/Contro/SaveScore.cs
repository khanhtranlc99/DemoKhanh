using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class SaveScore 
{
    public int score;
    public SaveScore(GameManager gameManager)
    {
        score = gameManager.score;
    }
}
