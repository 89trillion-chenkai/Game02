using Function3.Scripts;
using UnityEngine;

namespace Function2.Scripts
{
    /// <summary>
    /// 购买UI的按钮功能
    /// </summary>
    public class BuyUIButtonFunction : MonoBehaviour
    {
        public static int BuyNumber; //记录购买次数
        private GameObject _buyImage; //购买确认窗口
        private GameObject _showPosition; //窗口父物体
        void Start()
        {
            _buyImage = transform.Find("ImageBuy").gameObject;
            BuyNumber = 0;
        }

        public void ShowUIButton() //显示购买UI
        {
            if (_buyImage.gameObject.activeSelf == false)
            {
                if (_showPosition == null)
                {
                    _showPosition = GameObject.Find("UIRoot/ImageBackground/ImageScrollRect"); //寻找父物体
                }

                _buyImage.gameObject.SetActive(true);
                _buyImage.transform.SetParent(_showPosition.transform, false); //设置父物体
                _buyImage.transform.position = _showPosition.transform.position; //设置显示位置
            }
        }

        public void CloseUIButton() //关闭购买UI
        {
            _buyImage.gameObject.SetActive(false);
        }

        public void ConfirmButton() //确定购买
        {
            BuyNumber++; //购买次数加一
            GetComponent<DataManager>().UpdateBuyData(); //更新购买数据
            _buyImage.gameObject.SetActive(false); //关闭购买确认窗口
        }
    }
}
