using DG.Tweening;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

using UnityEngine;

public class Demo6 : MonoBehaviour
{
    public Animator animatorController;
    public Animator animatorController2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpControl();
        }
    }

    async void jumpControl()
    {

        animatorController2.SetTrigger("Jumping");

        await Task.Delay(1500);

        DOVirtual.Float(0, 1, 3, UpdateAnimation);

    }

    private void UpdateAnimation(float value)
    {
        Debug.Log(value);
        animatorController.SetFloat("Blend", value);
    }
}
