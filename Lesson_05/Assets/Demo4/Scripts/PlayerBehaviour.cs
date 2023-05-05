using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("FTUE"))
        {
            Debug.Log("FTUE");
            PlayerPrefs.SetString("FTUE", "OK");
        }
        else if (PlayerPrefs.HasKey("FTUE"))
        {
            Debug.Log("Experienced Gamer");
        }
    }

    private void Start()
    {

    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(0F, 0F, 1) * Time.deltaTime * 10;
    }



}
