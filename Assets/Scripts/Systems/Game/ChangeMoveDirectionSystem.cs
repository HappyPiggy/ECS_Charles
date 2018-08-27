using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 手柄数据填充到playerentity的方向中
/// </summary>
public class ChangeMoveDirectionSystem : ReactiveSystem<InputEntity>,IInitializeSystem
{
    private Contexts contexts;
    private InputContext context;
    private InputEntity controlPadInputEntity;
    private IGroup<GameEntity> heroGroup;

    private ConfigService configService;
    private MapInfo mapInfo;


    public ChangeMoveDirectionSystem(Contexts contexts,ConfigService configService) : base(contexts.input)
    {
        this.contexts = contexts;
        context = contexts.input;
        this.configService = configService;
    }

    public void Initialize()
    {
        controlPadInputEntity = context.controlPadInputEntity;
        heroGroup = contexts.game.GetGroup(GameMatcher.Hero);
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.MoveJoyStick);
    }

    protected override bool Filter(InputEntity entity)
    {
        return true;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        if (contexts.game.gameProgress.state == GameProgressState.InGame)
        {
            var dir = controlPadInputEntity.moveJoyStick.value;
            var rotation = MathUtils.Vector2Quaternion(dir);

            foreach (var item in heroGroup.GetEntities())
            {
                if (item.isHero)
                {
                    var newPos = CalcNewPos(item.position.value, dir);
                    item.ReplaceRotation(rotation);
                    if(item.isMover)
                        item.ReplacePosition(newPos);
                }
            }
        }
    }


    /// <summary>
    /// 计算可以到达的位置
    /// </summary>
    /// <param name="oldPos"></param>
    /// <param name="dir"></param>
    /// <returns></returns>
    private Vector2 CalcNewPos(Vector2 oldPos,Vector2 dir)
    {
        if (mapInfo == null)
            mapInfo = configService.GetMapInfo();

        var tmp = oldPos + dir/2 * Time.deltaTime;
        Vector2 pos = new Vector2(
            Mathf.Clamp(tmp.x, mapInfo.border.minX, mapInfo.border.maxX),
            Mathf.Clamp(tmp.y, mapInfo.border.minY, mapInfo.border.maxY)
            );
        return pos;
    }




}
