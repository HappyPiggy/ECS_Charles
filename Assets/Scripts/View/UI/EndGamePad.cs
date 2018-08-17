using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class EndGamePad:AppModule
{

    private float timer = 0;
    private bool isDelayShow = false;

    private Button restartBtn;

    protected override void OnStart()
    {
        base.OnStart();

        restartBtn = transform.Find("restartBtn").GetComponent<Button>();

        restartBtn.onClick.AddListener(OnRestartBtnClick);
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();

        timer += Time.deltaTime;
        if (timer >= ConstantUtils.collisionDelayTime && !isDelayShow)
        {
            isDelayShow = true;
            transform.DOLocalMoveY(0, 1f).SetEase(Ease.OutFlash); ;
        }
    }


    private void OnRestartBtnClick()
    {
        Contexts.sharedInstance.game.ReplaceGameProgress(GameProgressState.GameRestart);
    }

    public override void OnShow(object data = null)
    {
        base.OnShow(data);
        transform.localPosition = new Vector3(0, -Screen.height, 0);
    }

    public override void OnHide()
    {
        base.OnHide();
        isDelayShow = false;
        timer = 0;
    }
}