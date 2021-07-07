using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 控制主界面显示
/// </summary>
public class EnterUIControl : MonoBehaviour
{
    [SerializeField] private GameObject image; //主界面图片

    void Start()
    {
        image.SetActive(false);
    }

    //展示初始UI
    public void ShowUI()
    {
        image.SetActive(true);
    }
}
