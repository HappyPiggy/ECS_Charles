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

    private float spawnInterval = 0.05f; //生成子弹间隔
    private float timer = 999;

    private void Start()
    {
        bulletPos = transform.Find("bulletPos");
        viewObjectRoot = GameObject.Find("Game").transform;

        DoScale();
        Invoke("DelayDestroy", ConstantUtils.itemDuration+2);
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
        var curScale = scale;
        transform.localScale = Vector3.zero;
        transform.DOScale(curScale, 0.8f).SetEase(Ease.OutBounce);
    }

    private void DelayDestroy()
    {
        var hideTime = 0.8f;
        transform.DOScale(Vector3.zero, hideTime).SetEase(Ease.InBounce);
        Invoke("DestroySelf", hideTime);
    }

    private void DestroySelf()
    {
         gameEntity.ReplaceItemType(ItemType.None);
    }

    /// <summary>
    /// 生成子弹
    /// </summary>
    private void SpawnBullet()
    {
        var res = Resources.Load("Unit/Effect/Bullet");
        // GameObject go = GameObject.Instantiate(res, bulletPos.position, gameEntity.rotation.value, viewObjectRoot) as GameObject;
        GameObject go = PoolUtil.SpawnGameObject((GameObject)res, bulletPos.position, gameEntity.rotation.value, viewObjectRoot);
        go.name = res.name;
        if(go.GetComponent<BulletView>()==null)
            go.AddComponent<BulletView>();
    }
}