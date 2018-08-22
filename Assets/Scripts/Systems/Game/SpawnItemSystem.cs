using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 生成道具
/// </summary>
public class SpawnItemSystem : IExecuteSystem,IInitializeSystem
{
    private Contexts contexts;
    private Services services;
    private EntityFactoryService entityFactoryService;
    private ConfigService configService;

    private MapInfo mapInfo;
    private IGroup<GameEntity> itemGroup;

    private float timer = 0;


    public SpawnItemSystem(Contexts contexts, Services services)
    {
        this.contexts = contexts;
        this.services = services;
        this.entityFactoryService = services.entityFactoryService as EntityFactoryService;
        this.configService = services.configService;
    }


    public void Initialize()
    {
        itemGroup = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.ItemInfo).NoneOf(GameMatcher.Destroyed));
    }

    public void Execute()
    {
        if (contexts.game.gameProgress.state == GameProgressState.InGame)
        {
            timer += Time.deltaTime;
            var count = itemGroup.GetEntities().Length;
            if (timer >ConstantUtils.itemSpawnTime && count<ConstantUtils.maxItemInGame)
            {
                SpawnItemRandom();
                timer = 0;
            }
            
        } else if (contexts.game.gameProgress.state == GameProgressState.GameRestart)
        {
            timer = 0;
        }

    }

    /// <summary>
    /// 随机生成道具
    /// </summary>
    /// <param name="count"></param>
    private void SpawnItemRandom()
    {
        var pos = GetRandomPosition();
        entityFactoryService.CreateItem(UidUtils.Uid, pos);
    }


    /// <summary>
    /// 获得随机合法位置
    /// </summary>
    /// <returns></returns>
    private Vector2 GetRandomPosition()
    {
        if (mapInfo == null)
            mapInfo = configService.GetMapInfo();

        float x = MathUtils.RandomFloat(mapInfo.border.minX, mapInfo.border.maxX);
        float y = MathUtils.RandomFloat(mapInfo.border.minY, mapInfo.border.maxY);
        Vector2 pos = new Vector2(x, y);

        return pos;
    }


}
