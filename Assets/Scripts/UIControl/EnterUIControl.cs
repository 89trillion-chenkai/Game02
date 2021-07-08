using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 控制主界面显示
/// </summary>
public class EnterUIControl : MonoBehaviour
{
    [SerializeField] private GameObject imgMainInterface; //主界面图片

    void Start()
    {
        imgMainInterface.SetActive(false);
    }

    //展示初始UI
    public void ShowUI()
    {
        imgMainInterface.SetActive(true);
    }
}
