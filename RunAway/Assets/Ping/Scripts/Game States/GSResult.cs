﻿using UnityEngine;
using UnityEngine.UI;

public class GSResult : GSTemplate
{
    public Text lbCurrentScore;
    public Text lbBestScore;
    public Text lbStar;

    static GSResult _instance;
    public static GSResult Instance { get { return _instance; } }
    protected override void Awake()
    {
        base.Awake();
        _instance = this;
    }
    protected override void init()
    {
        showResult(GameController.Instance.Score);
        if (GSGamePlay.countPlaygame == 7 && GamePreferences.profile.Rate < 2)
        {
            GamePreferences.profile.Rate++;
            GamePreferences.saveProfile();
            PopupManager.Instance.InitYesNoPopUp("Love Block Dash?\nTell other how you fell.", onBtnRateClick, null, "RATE", "LATER");
        }
    }

    void showResult(int _score)
    {
        lbBestScore.text = "BEST   " + GamePreferences.profile.HighScore.ToString();
        lbCurrentScore.text = _score.ToString();
        if (lbStar != null)
        {
            lbStar.text = GamePreferences.profile.Star.ToString();
        }
    }
    protected override void onBackKey()
    {
        onBtnHomeClick();
    }

    public void onBtnPlayClick()
    {
        GameStatesManager.Instance.stateMachine.SwitchState(GSGamePlay.Instance);
    }

    public void onBtnLikeClick()
    {
        Application.OpenURL("https://www.facebook.com/");
    }

    public void onBtnHowToPlay()
    {
        GameStatesManager.Instance.stateMachine.SwitchState(GSTutorial.Instance);
    }
    public void onBtnRateClick()
    {
#if UNITY_IOS
            Application.OpenURL("");
#elif UNITY_ANDROID
            Application.OpenURL("https://play.google.com/");
#endif
    }
    public void onBtnBoardClick()
    {
    }
    public void onBtnHomeClick()
    {
        GameStatesManager.Instance.stateMachine.SwitchState(GSHome.Instance);
    }
    public void onBtnShopClick()
    {
        GameStatesManager.Instance.stateMachine.SwitchState(GSShop.Instance);
    }

}