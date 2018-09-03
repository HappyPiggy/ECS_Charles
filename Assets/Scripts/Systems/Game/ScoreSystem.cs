using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 计分系统
/// </summary>
public class ScoreSystem : ReactiveSystem<GameEntity>,IInitializeSystem
{
    private Contexts contexts;

    private Transform viewObjectRoot;


    public ScoreSystem(Contexts contexts) : base(contexts.game)
    {
        this.contexts = contexts;
    }

    public void Initialize()
    {
        contexts.game.SetGameCoin(0);
        contexts.game.SetGameScore(0);
        viewObjectRoot = GameObject.Find("Game").transform;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.EnemyState);
    }

    protected override bool Filter(GameEntity entity)
    {
        return true;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        if (contexts.game.gameProgress.state == GameProgressState.InGame)
        {
            foreach (var enemy in entities)
            {
                if (enemy.enemyState.value == EnemyState.Die)
                {
                    //todo 敌人身上应该带分数属性  不同敌人 分数不同
                    var coin = contexts.game.gameCoin.value + 1;
                    contexts.game.ReplaceGameCoin(coin);

                    //敌人死后金币特效
                    CreateIconEffect(enemy.position.value);
                }
            }
        }else if (contexts.game.gameProgress.state == GameProgressState.EndGame)
        {
            SavaScore();
            Contexts.sharedInstance.game.ReplaceGameCoin(0);

            // 弹出结算面板
            ModuleManager.Instance.Show(ModuleType.EndGamePad);
        }

    }

    /// <summary>
    /// 金币特效
    /// </summary>
    /// <param name="spawnPos"></param>
    private void CreateIconEffect(Vector3 spawnPos)
    {
        var res = Resources.Load("Unit/Effect/Coin");
        GameObject go = PoolUtil.SpawnGameObject((GameObject)res, spawnPos, Quaternion.identity, viewObjectRoot);
        go.name = res.name;
        if (go.GetComponent<CoinView>() == null)
            go.AddComponent<CoinView>();
    }


    /// <summary>
    /// 当前分数保存到存档
    /// </summary>
    private void SavaScore()
    {
        GlobalArchival archival = ArchivalUtils.Load<GlobalArchival>();

        var curScore = PlayerPrefs.GetInt("curScore");
        var score = archival.maxScore < curScore ? curScore : archival.maxScore;
        archival.maxScore = score;

        var curCoin = contexts.game.gameCoin.value;
        archival.coinNum += curCoin;
        ArchivalUtils.Save(archival);
    }


}
