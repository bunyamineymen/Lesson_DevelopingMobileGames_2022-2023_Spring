
<!-- # ![mg-builder](/img~/mg-builder.png) -->

# Lesson 1

Developing Mobile Game lesson for Ankara University - Week 5

## Demo 1

* Script Execution Order

<table>

  <tr>
    <td><img src="https://raw.githubusercontent.com/bunyamineymen/Lesson1_DevelopingMobileGame/main/Assets/_Resources/demo5.png"></td>

  </tr>
 </table>

```csharp

public class Demo5Script1 : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Start 1");
    }
}

public class Demo5Script2 : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Start 2");
    }
}

```
  
[👉 Learn more about Script Execution Order](https://docs.unity3d.com/Manual/class-MonoManager.html)

  ## Demo 2

* Access other monobehaviour script.

<table>

  <tr>
    <td><img src="https://raw.githubusercontent.com/bunyamineymen/Lesson1_DevelopingMobileGame/main/Assets/_Resources/demo6.png"></td>

  </tr>
 </table>

   ```csharp

public class Demo6Script1 : MonoBehaviour
{

    public Demo6Script2 demo6Script2;

    private void Start()
    {
        demo6Script2.MainLogic();
    }

}

public class Demo6Script2 : MonoBehaviour
{
    public void MainLogic()
    {
        Debug.Log("MainLogic");
    }
}

  ```

  ## Demo 3

* Singleton pattern

<table>

  <tr>
    <td><img src="https://raw.githubusercontent.com/bunyamineymen/Lesson1_DevelopingMobileGame/main/Assets/_Resources/demo7.png"></td>

  </tr>
 </table>

```csharp

public class Demo7 : MonoBehaviour
{
    #region Singleton

    public static Demo7 instance;

    private void Singleton()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    #endregion

    private void Awake()
    {
        Singleton();
    }

    public void MainMethod()
    {
        Debug.Log("MainMethod");
    }

}

public class Demo7Script2 : MonoBehaviour
{
    private void Start()
    {
        Demo7.instance.MainMethod();
    }
}

  ```

## Demo 4

* Scene Works
* Motion
* FixedUpdate

<table>

  <tr>
    <td><img src="https://raw.githubusercontent.com/bunyamineymen/Lesson2_DevelopingMobileGame/main/Assets/_Resources/demo1.png"></td>

  </tr>
 </table>

 ```csharp

using UnityEngine;

public class Player : MonoBehaviour
{
    private const float velocity = 700f;

    private void FixedUpdate()
    {
        transform.position += new Vector3(0f, 0, 0.001f) * velocity;
    }
}

  ```


[👉 Learn more about FixedUpdate](https://docs.unity3d.com/ScriptReference/MonoBehaviour.FixedUpdate.html)


  ## Demo 5

* PlayerPrefs
* PlayerPrefs editor

<table>

  <tr>
    <td><img src="https://raw.githubusercontent.com/bunyamineymen/Lesson2_DevelopingMobileGame/main/Assets/_Resources/demo2.png"></td>

  </tr>
 </table>

   ```csharp

public class Demo2 : MonoBehaviour
{

    private TextMeshProUGUI txt_Variable;

    private void Awake()
    {
        txt_Variable = GameObject.Find("Txt_Variable").GetComponent<TextMeshProUGUI>();

        if (PlayerPrefs.HasKey("Variable"))
        {
            txt_Variable.text = PlayerPrefs.GetString("Variable");
        }
    }

    private void Start()
    {
        if (!PlayerPrefs.HasKey("Variable"))
        {
            PlayerPrefs.SetString("Variable", "This is variable !!!");
            PlayerPrefs.SetInt("Score", 9);
            PlayerPrefs.SetFloat("percentage", 0.67f);
        }
    }

}

  ```

[👉 Learn more about PlayerPrefs](https://docs.unity3d.com/ScriptReference/PlayerPrefs.html)


