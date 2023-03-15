using UnityEngine;
using UnityEngine.UI;

public class Demo4 : MonoBehaviour
{

    private Button BtnButtonClick;

    private void Awake()
    {
        BtnButtonClick = GameObject.Find("Button").GetComponent<Button>();
        BtnButtonClick.onClick.AddListener(PurchaseCoin);
    }

    public void PurchaseCoin()
    {
        Debug.Log("PurchaseCoin");
    }
}
