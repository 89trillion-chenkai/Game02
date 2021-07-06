using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 控制主界面显示
/// </summary>
public class EnterUIControl : MonoBehaviour
{
    [SerializeField]
    private Image image; //主界面图片

    void Start()
    {
        image.gameObject.SetActive(false);
    }

    //展示初始UI
    public void ShowUI()
    {
        image.gameObject.SetActive(true);
    }
}
