using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class InGamePad:AppModule,IGameCoinListener
{
    private Text coinNumText;
    private Text gameTimeText;
    private float timer = 0;

    private GameEntity gameEntity;




    public override void OnShow(object data = null)
    {
        base.OnShow(data);

        gameEntity = Contexts.sharedInstance.game.CreateEntity();
        gameEntity.AddGameCoinListener(this);

        coinNumText = transform.Find("bg/coinIcon/num").GetComponent<Text>();
        gameTimeText = transform.Find("bg/gameTime").GetComponent<Text>();

        coinNumText.text = "0";
        gameTimeText.text = "0";
    }


    protected override void OnUpdate()
    {
        base.OnUpdate();

        timer += Time.deltaTime;
        gameTimeText.text = ((int)timer).ToString();
    }


    public void OnGameCoin(GameEntity entity, int value)
    {
        if (coinNumText != null)
            coinNumText.text = value.ToString();
    }
    public override void OnHide()
    {
        base.OnHide();
        PlayerPrefs.SetInt("curScore", (int)timer);
        gameEntity.RemoveGameCoinListener(this);
        gameEntity.Destroy();
        gameEntity = null;
        timer = 0;
    }


}