using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

namespace UIControl
{
    /// <summary>
    /// 购买UI的按钮功能
    /// </summary>
    public class BuyUIButtonFunction : MonoBehaviour
    {
        public static int BuyNumber; //记录购买次数
        public GameObject buyImage; //购买确认窗口
        public GameObject showPosition; //将被设置为窗口的父物体
        void Start()
        {
            BuyNumber = 0; //初始化购买次数
        }

        //显示购买UI
        public void ShowUIButton() 
        {
            if (buyImage.gameObject.activeSelf == false)
            {
                buyImage.gameObject.SetActive(true); 
                buyImage.transform.SetParent(showPosition.transform, false); //设置背景图片为其父物体
                buyImage.transform.GetComponent<RectTransform>().anchoredPosition3D = Vector3.zero; //设置位置居中
            }
        }

        //关闭购买UI
        public void CloseUIButton() 
        {
            buyImage.gameObject.SetActive(false);
        }

        //确定购买时调用
        public void ConfirmButton() 
        {
            BuyNumber++; //购买次数加一
            GetComponent<DataManagers.DataUpdate>().UpdateBuyData(); //更新购买数据
            buyImage.gameObject.SetActive(false); //关闭购买确认窗口
        }
    }
}
