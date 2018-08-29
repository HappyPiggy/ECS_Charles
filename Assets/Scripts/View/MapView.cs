using DG.Tweening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
/// <summary>
/// 游戏地图的view
/// </summary>
public class MapView : BaseView,IGameProgressListener
{

    private void Start()
    {
        gameEntity.AddGameProgressListener(this);
    }



    public void OnGameProgress(GameEntity entity, GameProgressState state)
    {
     //   Debug.Log("GameRestart "+ state);

        if (state== GameProgressState.GameRestart)
        {
            CleanGameScene();
        }
    }

    /// <summary>
    /// 清除游戏场景数据
    /// </summary>
    private void CleanGameScene()
    {
        UidUtils.ResetUid();
        DOTween.Clear();
        ModuleManager.Instance.HideAll();

        gameEntity.isDestroyed = true;
        Contexts.sharedInstance.game.ReplaceGameProgress(GameProgressState.StartGame);
        OnDestroyedView();
    }


}