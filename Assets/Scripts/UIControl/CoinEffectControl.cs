using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

/// <summary>
/// 金币产生及动画
/// </summary>
public class CoinEffectControl : MonoBehaviour
{
    [SerializeField] private Transform coinPrefab; //金币预制体，需拖拽
    [SerializeField] private Transform targetTransform; //用于获取目标物体位置，需拖拽
    [SerializeField] private Animator boxImageAnimator; //宝箱的动画控制器，需拖拽
    [SerializeField] private ParticleSystem lightEffect; //开箱炫光特效，需拖拽
    [SerializeField] private PlayerInfo playerInfo; //用于调用显示玩家金币钻石信息函数的脚本，需拖拽
    [SerializeField] private BuyManager buyManager; //用于调用更新购买后数据函数的脚本，需拖拽

    //间隔产生金币的协程
    IEnumerator DelayedGenerate()
    {
        int coinNum = Mathf.Clamp(PlayerInfo.buyNumber * 5, 5, 15); //计算特效飞出金币数并限制金币数最大15枚
        boxImageAnimator.SetBool("boxOpenBool", true); //开启开箱动画
        lightEffect.Play(); //开启开箱炫光特效

        for (int i = 0; i < coinNum; ++i) 
        {
            Transform coin = Instantiate(coinPrefab, transform, false); //实例化生成
            yield return new WaitForSeconds(0.1f);
            coin.DOMove(targetTransform.position, 0.3f); //移动到指定位置
            Destroy(coin.gameObject, 0.5f); //延迟销毁
        }
        
        yield return new WaitForSeconds(0.3f);
        lightEffect.Stop(); //关闭开箱炫光特效
        lightEffect.Clear(); //清除炫光效果
        boxImageAnimator.SetBool("boxOpenBool", false); //结束开箱动画
        buyManager.UpdateCoinAndDiamondData(); //更新金币和钻石数据
        playerInfo.SetCoinAndDiamondsInfo(); //更新玩家界面上的金币和钻石信息
    }

    //展示金币动画
    public void CoinAnimation()
    {
        StartCoroutine("DelayedGenerate"); //开启协程
    }
}
