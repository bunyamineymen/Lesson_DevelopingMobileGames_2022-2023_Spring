using UnityEngine;

public class Demo3Script1 : MonoBehaviour
{

    #region Monobehaviour

    private void Awake()
    {
        Singleton();
    }

    #endregion

    #region Singleton

    public static Demo3Script1 Instance;

    private void Singleton()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    #endregion

    public void RunDebugLog()
    {
        Debug.Log("RunDebugLog");
    }

}
