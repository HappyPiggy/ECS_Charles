using DG.Tweening;
using Entitas;
using Entitas.Unity;
using UnityEngine;
/// <summary>
/// 机关枪view
/// </summary>
public class MachineGunView : BaseView
{
    private float curEuler = 0;
    private float oldEuler = 0;

    private void Start()
    {
        DoScale();
        Invoke("DelayDestroy", 3f);
    }
    protected override void Update()
    {
        transform.rotation = gameEntity.rotation.value;
    }



    private void DoScale()
    {
        var curScale = scale;
        transform.localScale = Vector3.zero;
        transform.DOScale(curScale, 0.5f).SetEase(Ease.OutBounce);
    }

    private void DelayDestroy()
    {
        gameEntity.isDestroyed = true;
    }
}