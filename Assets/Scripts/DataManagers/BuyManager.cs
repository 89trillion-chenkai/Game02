using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

/// <summary>
/// 购买管理
/// </summary>
public class BuyManager : MonoBehaviour
{
    [SerializeField] private Text txtPrice; //购买价格文本，需拖拽
    [SerializeField] private Text txtCoinNumber; //购买获得的金币数量，需拖拽
    [SerializeField] private CoinEffectControl coinEffectControl; //产生金币飞舞效果脚本，需拖拽
    private int buyPriceNumber; //记录购买所需钻石数
    private int buyCoinNumber; //记录购买所需的金币数

    void Start()
    {
        buyPriceNumber = int.Parse(txtPrice.text); //购买价格
        buyCoinNumber = int.Parse(txtCoinNumber.text); //购买所获金币，数值为5枚
    }

    //判断是否能购买
    public void IfBuySuccess()
    {
        int priceDifference = PlayerInfo.diamondsNumber - buyPriceNumber; //计算自有钻石和购买所需之差

        if (priceDifference >= 0)
        {
            coinEffectControl.CoinAnimation(); //产生金币飞舞效果
        }
    }

    //更新玩家金币和钻石数据金币
    public void UpdateCoinAndDiamondData()
    {
        PlayerInfo.buyNumber++; //购买次数更新
        PlayerInfo.coinNumber += buyCoinNumber * PlayerInfo.buyNumber; //更新购买后金币总数，购买金币数=购买次数*5
        PlayerInfo.diamondsNumber -= buyPriceNumber; //更新购买后钻石总数
    }
}

