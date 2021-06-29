using UIControl;
using UnityEngine;
using UnityEngine.UI;

namespace DataManagers
{
    /// <summary>
    /// 更新金币、钻石数据
    /// </summary>
    public class DataUpdate : MonoBehaviour
    {
        public Text imageCoins; //购买金币图片
        public Text imageDiamonds; //购买花费钻石图片
        public Text imagePrice; //购买所需金币图片
        public Text imageCoinNumber; //购买所需钻石图片
        public Image imageBackground; //背景图片
        private string priceStr; //钻石数
        private string coinNumberStr; //金币数

        void Start()
        {
            priceStr = imagePrice.text; //购买价格
            coinNumberStr = imageCoinNumber.text; //购买所获金币
        }

        //更新购买数据
        public void UpdateBuyData()
        {
            string coinsStr = imageCoins.text; //每次购买时重新获取玩家钻石数量
            string diamondsStr = imageDiamonds.text; //每次购买时重新获取玩家金币数量
            int priceDifference = int.Parse(diamondsStr) - int.Parse(priceStr); //计算自有钻石和购买所需之差
            double diamondsDifference = double.Parse(coinsStr) + double.Parse(coinNumberStr) / 1000; //计算购买后金币总数

            if (priceDifference >= 0)
            {
                imageBackground.GetComponent<CoinControl>().CoinAnimation(); //产生金币飞舞效果
                imageDiamonds.text = priceDifference.ToString(); //更新玩家钻石数量
                imageCoins.text = diamondsDifference.ToString(); //更新玩家金币数量
            }
            else
            {
                Debug.Log("钻石不足！！！");
            }
        }
    }
}
