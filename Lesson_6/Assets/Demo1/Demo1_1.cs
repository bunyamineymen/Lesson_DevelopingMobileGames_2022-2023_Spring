
using UnityEngine;
using UnityEngine.SceneManagement;

public class Demo1_1 : MonoBehaviour
{

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void GoToScene2()
    {
        SceneManager.LoadScene("Demo1_2");
    }

}
