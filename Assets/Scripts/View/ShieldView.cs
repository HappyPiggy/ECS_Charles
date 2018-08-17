using DG.Tweening;
using UnityEngine;
/// <summary>
/// 保护罩view
/// </summary>
public class ShieldView:BaseView
{

    private float delayTime = 0.5f;


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
        transform.DOScale(curScale, delayTime).SetEase(Ease.OutBounce);

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }

    public override void OnDestroyedView()
    {

    }


}