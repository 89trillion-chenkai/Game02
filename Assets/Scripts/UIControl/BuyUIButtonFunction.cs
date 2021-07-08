using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

/// <summary>
/// 购买UI的按钮功能
/// </summary>
public class BuyUIButtonFunction : MonoBehaviour
{
    [SerializeField] private RectTransform imgBuyRectTransform; //购买确认窗口，需拖拽
    [SerializeField] private Transform imgParentTransform; //将被设置为窗口的父物体，需拖拽
    [SerializeField] private BuyManager buyManager; //更新购买数据脚本，需拖拽
    
    //显示购买UI
    public void ShowBuyUIButton()
    {
        if (imgBuyRectTransform.gameObject.activeSelf == false)
        {
            imgBuyRectTransform.gameObject.SetActive(true);
            imgBuyRectTransform.SetParent(imgParentTransform, false); //设置其父物体
            imgBuyRectTransform.anchoredPosition3D = Vector3.zero; //设置位置居中
        }
    }

    //关闭购买UI
    public void CloseBuyUIButton()
    {
        imgBuyRectTransform.gameObject.SetActive(false);
    }

    //确定购买时调用
    public void ConfirmBuyButton()
    {
        buyManager.IfBuySuccess(); //判断是否能购买
        imgBuyRectTransform.gameObject.SetActive(false); //关闭购买确认窗口
    }
}

