using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public static UI ui;
    public UiEndGame uiEndGame;
    public UIGamePlay uIGamePlay;
    public UIMenu uiMenu;
    private void Awake()
    {
        ui = this;
        ChangeUI(MenuUI.menu);
    }
    public void ChangeUI(MenuUI menuUI)
    {
        uiEndGame.Show(menuUI == MenuUI.endGame);
        uIGamePlay.Show(menuUI == MenuUI.gamePlay);
        uiMenu.Show(menuUI == MenuUI.menu);
    }

    public enum MenuUI
    {
        endGame,
        gamePlay,
        menu

    }

    }
