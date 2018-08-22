using DG.Tweening;
using Entitas;
using Entitas.Unity;
using UnityEngine;
/// <summary>
/// 机关枪view
/// </summary>
public class MachineGunView : BaseView
{
    private void Start()
    {
        DoScale();
    }
    protected override void Update()
    {
        
    }



    private void DoScale()
    {
        var curScale = scale;
        transform.localScale = Vector3.zero;
        transform.DOScale(curScale, 0.5f).SetEase(Ease.OutBounce);
    }
}