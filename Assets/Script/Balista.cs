using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Balista : MonoBehaviour
{
   public TMP_Text endText;
   public Image _blur;
   public Button _restart;
    void Start()
    {
        endText.gameObject.SetActive(false);
        _blur.gameObject.SetActive(false);
        _restart.gameObject.SetActive(false);
    }
    private void OnDestroy() {
        endText.gameObject.SetActive(true);
        _blur.gameObject.SetActive(true);
        _restart.gameObject.SetActive(true);
    }

    
}
