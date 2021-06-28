using UnityEngine;
using UnityEngine.UI;

namespace Function1.Scripts
{
    /// <summary>
    /// 控制主界面显示
    /// </summary>
    public class EnterUIControl : MonoBehaviour
    {
        public Image image; //主界面图片
    
        void Start()
        {
            image.gameObject.SetActive(false);
        }

        public void ShowUI()
        {
            image.gameObject.SetActive(true);
        }
    }
}
