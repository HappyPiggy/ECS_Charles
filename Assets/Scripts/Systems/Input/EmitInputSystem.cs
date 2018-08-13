using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 从外部(摇杆，控制器等)获取player的输入，传输到ecs系统中
/// </summary>
public class EmitInputSystem : IExecuteSystem,IInitializeSystem
{
    private InputContext context;
    private IInputService inputService;
    private InputEntity controlPadInputEntity; //代表ControlPad 在ecs系统中的entity

    public EmitInputSystem(Contexts contexts, IInputService inputService) 
    {
        this.context = contexts.input;
        this.inputService = inputService;
    }

    public void Initialize()
    {
        context.isControlPadInput = true; //为了创建实例
        controlPadInputEntity = context.controlPadInputEntity;
    }

    public void Execute()
    {
        var movement = inputService.MoveJoystick;
        //Debug.Log("movement" + movement);
        controlPadInputEntity.ReplaceMoveJoyStick(movement);
    }

  
}
