using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class EndGamePad:AppModule
{

    private float timer = 0;
    private bool isDelayShow = false;

    private Button restartBtn;
    private Text maxScoreText;
    private Text curScoreText;


    protected override void OnUpdate()
    {
        base.OnUpdate();

        timer += Time.deltaTime;
        if (timer >= 1&& !isDelayShow)
        {
            isDelayShow = true;
            transform.DOLocalMoveY(0, 1f).SetEase(Ease.OutFlash); ;
        }
    }


    private void OnRestartBtnClick()
    {
        //ui特效音
        var clip = Contexts.sharedInstance.meta.configService.instance.GetAudio("pop1");
        Contexts.sharedInstance.meta.unityAudioService.instance.PlaySound(clip);

        Contexts.sharedInstance.game.ReplaceGameProgress(GameProgressState.GameRestart);
    }

    public override void OnShow(object data = null)
    {
        base.OnShow(data);
        restartBtn = transform.Find("restartBtn").GetComponent<Button>();
        maxScoreText = transform.Find("maxScore/score").GetComponent<Text>();
        curScoreText = transform.Find("curScore/score").GetComponent<Text>();

        restartBtn.onClick.AddListener(OnRestartBtnClick);


        transform.localPosition = new Vector3(0, -Screen.height, 0);
        ShowScore();
    }

    public override void OnHide()
    {
        base.OnHide();
        isDelayShow = false;
        timer = 0;
    }

    /// <summary>
    /// 结算面板显示分数
    /// </summary>
    private void ShowScore()
    {
        maxScoreText.text=ArchivalUtils.Load<GlobalArchival>().maxScore.ToString();
        curScoreText.text = PlayerPrefs.GetInt("curScore").ToString();
    }
}