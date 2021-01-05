using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public  int score;
    [SerializeField] private Image menuImage;
    [SerializeField] private Text textScore;
    [SerializeField] private int scoreFalse;
    [SerializeField] private Text textFalse;
    [SerializeField] private Text textOut;
    public AudioSource audio;
    string path;
    private void Awake()
    {
        instance = this;
        path = Application.persistentDataPath + "Score";
    }
    private void Start()
    {
        _Load();
        audio.Pause();
    }
    private void Update()
    {
        if( scoreFalse == 3)
        {
            InstadiateBox.instadiate._Pause();
            UI.ui.ChangeUI(UI.MenuUI.endGame);
        }    

    }
    /// <summary>
    /// ///////////////////
    /// </summary>
    public void _ButtonStart()
    {
        _Reset();
        UI.ui.ChangeUI(UI.MenuUI.gamePlay);
        audio.Play();
        StartCoroutine( InstadiateBox.instadiate._PlusBlox());
         if(InstadiateBox.instadiate.wasOn == false)
        {
            InstadiateBox.instadiate.wasOn = true;
        }    
    }    
    public void _ButtonInEndGame()
    {
        UI.ui.ChangeUI(UI.MenuUI.menu);
        _Save();
    }    
    
    /// <summary>
    /// ///////////////
    /// </summary>
    public void _PlusScore()
    {
        score += 1;
        textScore.text = "" + score;
    }
    public void _PlusFase()
    {
        scoreFalse += 1;
        textFalse.text = "" + scoreFalse;
    }
    //////////////////////
    /// <summary>
    /// 
    /// </summary>
    public void _Reset()
    {
        score = 0;
        scoreFalse = 0;
        textFalse.text = "" + scoreFalse;
        textScore.text = "" + score;
    }    
    public void _Save()
    {
        SaveScore saveScore = new SaveScore(this);
        SaveSystem.SaveData<SaveScore>(saveScore, path);
    }
     private void _Load()
    {
        if (File.Exists(path))
        {
            SaveScore data = SaveSystem.LoadData<SaveScore>(path);
            score = data.score;
            textOut.text = "" + score;

        }
    }

}
