using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

/// <summary>
/// 更新金币、钻石数据
/// </summary>
public class CoinDataUpdate : MonoBehaviour
{
    [SerializeField] private Text imagePrice; //购买所需金币图片，需拖拽
    [SerializeField] private Text imageCoinNumber; //购买所需钻石图片，需拖拽
    [FormerlySerializedAs("coinControl")] [SerializeField] private CoinEffectControl coinEffectControl; //产生金币飞舞效果脚本，需拖拽
    [SerializeField] private Animator boxImageAnimator; //宝箱的动画控制器，需拖拽
    [SerializeField] private ParticleSystem lightEffect; //开箱炫光特效，需拖拽
    private int buyPriceNumber; //记录购买所需钻石数
    private int buyCoinNumber; //记录购买所需的金币数

    void Start()
    {
        buyPriceNumber = int.Parse(imagePrice.text); //购买价格
        buyCoinNumber = int.Parse(imageCoinNumber.text); //购买所获金币，数值为5枚
    }

    //更新购买数据
    public void UpdateBuyData()
    {
        int priceDifference = PlayerInfo.diamondsNumber - buyPriceNumber; //计算自有钻石和购买所需之差

        if (priceDifference >= 0)
        {
            PlayerInfo.buyNumber++; //购买次数更新
            PlayerInfo.coinNumber += buyCoinNumber * PlayerInfo.buyNumber; //更新购买后金币总数，购买金币数=购买次数*5
            PlayerInfo.diamondsNumber = priceDifference; //更新购买后钻石总数
            boxImageAnimator.SetBool("boxOpenBool", true); //开启开箱动画
            lightEffect.Play(); //开启开箱炫光特效
            coinEffectControl.CoinAnimation(); //产生金币飞舞效果
        }
    }
}

