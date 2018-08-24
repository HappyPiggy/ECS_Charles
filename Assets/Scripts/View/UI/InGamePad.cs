using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class InGamePad:AppModule,IGameScoreListener
{
    private Text coinNumText;
    private GameEntity gameEntity;




    public override void OnShow(object data = null)
    {
        base.OnShow(data);

        gameEntity = Contexts.sharedInstance.game.CreateEntity();
        gameEntity.AddGameScoreListener(this);

        coinNumText = transform.Find("bg/coinIcon/num").GetComponent<Text>();
        coinNumText.text = "0";
    }


    public void OnGameScore(GameEntity entity, int value)
    {
        if (coinNumText != null)
            coinNumText.text = value.ToString();
    }

    public override void OnHide()
    {
        base.OnHide();
        gameEntity.RemoveGameScoreListener(this);
        gameEntity.Destroy();
        gameEntity = null;
    }
}