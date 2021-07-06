using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

/// <summary>
/// 金币产生及动画
/// </summary>
public class CoinControl : MonoBehaviour
{
    [SerializeField]
    private GameObject coinPrefab; //金币预制体，需拖拽
    [SerializeField]
    private Transform target; //目标物体位置，需拖拽
    [SerializeField]
    private PlayerInfo playerInfo; //调用更新玩家金币钻石信息的脚本，需拖拽
    [SerializeField]
    private Animator boxImageAnimator; //宝箱的动画控制器，需拖拽
    [SerializeField]
    private ParticleSystem lightEffect; //开箱炫光特效，需拖拽

    //间隔产生金币的协程
    IEnumerator Delayed()
    {
        int coinNum = Mathf.Clamp(PlayerInfo.buyNumber * 5, 5, 15); //计算特效飞出金币数并限制金币数最大15枚

        for (int i = 0; i < coinNum; ++i) 
        {
            GameObject coin = Instantiate(coinPrefab, transform, false); //实例化生成
            yield return new WaitForSeconds(0.1f);
            coin.transform.DOMove(target.position, 0.3f); //移动到指定位置
            Destroy(coin.gameObject, 0.5f);
        }
        
        yield return new WaitForSeconds(0.3f);
        lightEffect.Stop(); //关闭开箱炫光特效
        lightEffect.Clear(); //清除炫光效果
        boxImageAnimator.SetBool("boxOpenBool", false); //结束开箱动画
        playerInfo.SetCoinAndDiamondsInfo(); //更新玩家界面上的金币和钻石信息
    }

    //展示金币动画
    public void CoinAnimation()
    {
        StartCoroutine(nameof(Delayed)); //开启协程
    }
}
