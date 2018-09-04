using DG.Tweening;
using Entitas;
using Entitas.Unity;
using UnityEngine;
/// <summary>
/// 保护罩view
/// </summary>
public class ShieldView:BaseView//,IGameDestroyedListener
{

    private float delayTime = 0.5f;


    private void Start()
    {
       // gameEntity.AddGameDestroyedListener(this);
        DoScale();

        var clip = Contexts.sharedInstance.meta.configService.instance.GetAudio("shield_state");
        Contexts.sharedInstance.meta.unityAudioService.instance.PlaySound(clip);
    }



    protected override void Update()
    {
        transform.localPosition = gameEntity.position.value;
    }

    private void DoScale()
    {
        var curScale = scale;
        transform.localScale = Vector3.zero;
        transform.DOScale(curScale, delayTime).SetEase(Ease.OutBounce);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            gameEntity.ReplaceOnTriggerEnter(collision);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            gameEntity.ReplaceOnTriggerEnter(collision);
        }
    }

    public override void OnDestroyedView()
    {
        base.OnDestroyedView();
    }

    //public void OnDestroyed(GameEntity entity)
    //{
    //    OnDestroyedView();
    //}
}