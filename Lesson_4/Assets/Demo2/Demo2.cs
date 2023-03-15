using UnityEngine;
using UnityEngine.UI;

public class Demo2 : MonoBehaviour
{

    [SerializeField]
    private Button BtnButtonClick;

    private void Awake()
    {
        BtnButtonClick.onClick.AddListener(

            delegate ()
            {
                Debug.Log("PurchaseCoin !!!");
            }

            );
    }



    void Update()
    {
        //Debug.Log("Developing Mobile Game !!");
    }

    public void PurchaseCoin()
    {
    }
}
