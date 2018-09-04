using DG.Tweening;
using Entitas;
using Entitas.Unity;
using UnityEngine;
/// <summary>
/// 机关枪view
/// </summary>
public class MachineGunView : BaseView
{

    private Transform bulletPos;
    private Transform viewObjectRoot;

    private float spawnInterval = 0.1f; //生成子弹间隔
    private float hideTime = 0.3f; //道具消除播放动画时间
    private float timer = 999;

    private AudioClip clip;

    private void Start()
    {
        bulletPos = transform.Find("bulletPos");
        viewObjectRoot = GameObject.Find("Game").transform;

        DoScale();
        Invoke("DelayDestroy", ConstantUtils.itemDuration);
        Camera.main.transform.DOShakePosition(ConstantUtils.itemDuration+ hideTime, new Vector3(-0.1f, -0.1f, 0),10,90,false,false);



    }
    protected override void Update()
    {
        transform.rotation = gameEntity.rotation.value;
        if (timer >= spawnInterval)
        {
            
            SpawnBullet();
            timer = 0;
        }
        timer += Time.deltaTime;
    }



    private void DoScale()
    {
        var clip = Contexts.sharedInstance.meta.configService.instance.GetAudio("pre_machine");
        Contexts.sharedInstance.meta.unityAudioService.instance.PlaySound(clip);

        float startTime = 1f;

        var curScale = scale;
        transform.localScale = Vector3.zero;
        transform.DOScale(curScale, startTime).SetEase(Ease.OutBounce);

    }

    private void DelayDestroy()
    {
        
        transform.DOScale(Vector3.zero, hideTime).SetEase(Ease.InBounce);
        Invoke("DestroySelf", hideTime);
    }

    private void DestroySelf()
    {
        Contexts.sharedInstance.meta.unityAudioService.instance.StopSound();
         gameEntity.ReplaceItemType(ItemType.None,gameEntity.itemType.value);
    }

    /// <summary>
    /// 生成子弹
    /// </summary>
    private void SpawnBullet()
    {
        var res = Resources.Load("Unit/Effect/Bullet");
        GameObject go = PoolUtil.SpawnGameObject((GameObject)res, bulletPos.position, gameEntity.rotation.value, viewObjectRoot);
        go.name = res.name;

        if(go.GetComponent<BulletView>()!=null)
            Destroy(go.GetComponent<BulletView>());

        go.AddComponent<BulletView>();
    }
}