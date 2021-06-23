using UnityEngine;


/// <summary>
/// 购买UI的按钮功能
/// </summary>
public class BuyUIButtonFunction : MonoBehaviour
{
    public static int BuyNumber; //记录购买次数
    private GameObject _buyImage; //购买确认窗口
    
    void Start()
    {
        _buyImage = transform.Find("ImageBuy").gameObject;
        BuyNumber = 0;
    }

    public void ShowUIButton() //显示购买UI
    {
        if (_buyImage.gameObject.activeSelf == false)
        {
            _buyImage.gameObject.SetActive(true);
            //_buyImage.transform.position = GameObject.Find("Root/ImageBackground/ImageScrollRect").transform.position;
        }
    }

    public void CloseUIButton() //关闭购买UI
    {
        _buyImage.gameObject.SetActive(false);
    }

    public void ConfirmButton() //确定购买
    {
        BuyNumber++;
        GetComponent<DataManager>().UpdateBuyData();
        _buyImage.gameObject.SetActive(false);
    }
}
