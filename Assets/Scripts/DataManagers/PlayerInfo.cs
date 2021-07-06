using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 玩家信息
/// </summary>
public class PlayerInfo : MonoBehaviour
{
    public static int coinNumber; //玩家具有的金币数
    public static int diamondsNumber; //玩家具有的钻石数
    public static int buyNumber; //玩家购买购买次数
    [SerializeField]
    private Text imageCoins; //玩家金币文本，需拖拽
    [SerializeField]
    private Text imageDiamonds; //玩家钻石文本，需拖拽
    
    void Start()
    {
        coinNumber = 0;
        diamondsNumber = 1847;
        buyNumber = 0;
        SetCoinAndDiamondsInfo(); //设置玩家的金币和钻石信息
    }

    //设置玩家的金币和钻石信息
    public void SetCoinAndDiamondsInfo()
    {
        imageDiamonds.text = diamondsNumber.ToString(); //设置玩家钻石数量
        imageCoins.text = coinNumber.ToString(); //设置玩家金币数量
    }
}
