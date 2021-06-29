using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace UIControl
{
    /// <summary>
    /// 金币产生及动画
    /// </summary>
    public class CoinControl : MonoBehaviour
    {
        private GameObject target; //目标物体位置
        private Image coinPrefab; //金币预制体

        void Start()
        {
            coinPrefab = Resources.Load<Image>("Prefabs/ImageCoin"); //加载金币预制体
            target = GameObject.Find("UIRoot/ImageBackground/ImageTopMoneyUI/ImageCoins/ImageMask"); //获取指定目标位置
        }

        //间隔产生金币的协程
        IEnumerator Delayed() 
        {
            int coinNum = BuyUIButtonFunction.BuyNumber * 5; //计算飞出金币数

            for (int i = 0; i < coinNum && i < 15; ++i) //限制金币数最大15枚
            {
                Image coin = Instantiate(coinPrefab, transform, false); //实例化生成
                yield return new WaitForSeconds(0.1f);
                coin.transform.DOMove(target.transform.position, 0.3f); //移动到指定位置
                Destroy(coin.gameObject, 0.5f);
            }
        }
    
        //展示金币动画
        public void CoinAnimation()
        {
            StartCoroutine(nameof(Delayed)); //开启协程
        }
    }
}
