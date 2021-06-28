using UnityEngine;
using UnityEngine.UI;

namespace Function3.Scripts
{
    /// <summary>
    /// 更新金币、钻石数据
    /// </summary>
    public class DataManager : MonoBehaviour
    {
        private GameObject _imageCoins; //购买金币图片
        private GameObject _imageDiamonds; //购买花费钻石图片
        private string _price; //钻石数
        private string _coinNumber; //金币数

        void Start()
        {
            _imageCoins = GameObject.Find("UIRoot/ImageBackground/ImageTopMoneyUI/ImageCoins/TextNumber");
            _imageDiamonds = GameObject.Find("UIRoot/ImageBackground/ImageTopMoneyUI/ImageDiamonds/TextNumber");
            _price = transform.Find("BuyButton/Text").GetComponent<Text>().text;
            _coinNumber = transform.Find("TextCoin").GetComponent<Text>().text;
        }

        public void UpdateBuyData()
        {
            string coinsStr = _imageCoins.GetComponent<Text>().text;
            string diamondsStr = _imageDiamonds.GetComponent<Text>().text;
            int priceDifference = int.Parse(diamondsStr) - int.Parse(_price); //计算自有钻石和购买所需之差
            double diamondsDifference = double.Parse(coinsStr) + double.Parse(_coinNumber) / 1000; //计算购买后金币总数

            if (priceDifference >= 0)
            {
                GameObject.Find("UIRoot/ImageBackground").GetComponent<CoinControl>().CoinAnimation(); //产生金币飞舞效果
                _imageDiamonds.GetComponent<Text>().text = priceDifference.ToString();
                _imageCoins.GetComponent<Text>().text = diamondsDifference.ToString();
            }
            else
            {
                Debug.Log("钻石不足！！！");
            }
        }
    }
}
