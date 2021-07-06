using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

/// <summary>
/// 购买UI的按钮功能
/// </summary>
public class BuyUIButtonFunction : MonoBehaviour
{
    [SerializeField]
    private GameObject buyImage; //购买确认窗口，需拖拽
    [SerializeField]
    private GameObject showPosition; //将被设置为窗口的父物体，需拖拽

    //显示购买UI
    public void ShowBuyUIButton()
    {
        if (buyImage.gameObject.activeSelf == false)
        {
            buyImage.gameObject.SetActive(true);
            buyImage.transform.SetParent(showPosition.transform, false); //设置背景图片为其父物体
            buyImage.transform.GetComponent<RectTransform>().anchoredPosition3D = Vector3.zero; //设置位置居中
        }
    }

    //关闭购买UI
    public void CloseBuyUIButton()
    {
        buyImage.gameObject.SetActive(false);
    }

    //确定购买时调用
    public void ConfirmBuyButton()
    {
        GetComponent<CoinDataUpdate>().UpdateBuyData(); //更新购买数据
        buyImage.gameObject.SetActive(false); //关闭购买确认窗口
    }
}

