using DG.Tweening;

using System.Collections;

using UnityEngine;

public class PlayerDemo1 : MonoBehaviour
{

    public Transform targetGameObject;

    public PlayerDemo1SO data;

    Tween movement;


    void Start()
    {
        StartCoroutine(StopEndlessLoopMovement());

        Vector3 target = targetGameObject.position;

        movement = gameObject.transform.DOMove(target, data.speed)
       .SetRelative(false)
       .SetEase(Ease.Linear)
       .SetSpeedBased(true)
       .SetLoops(5, LoopType.Yoyo);



        movement.onUpdate = delegate
        {
            Debug.Log("Dotween Update Callback");
        };


        movement.onComplete = delegate
        {
            //Debug.Log("Movement has finished !!!");
        };

        movement.onStepComplete = delegate
        {
            //Debug.Log("onStepComplete !!!");
        };

        //transform.DORotate(Vector3.up * 360, 2, RotateMode.FastBeyond360);

    }



    IEnumerator StopEndlessLoopMovement()
    {
        yield return new WaitForSeconds(3f);

        // Time to terminate dotween

        movement.Kill(true);



    }

    //gameObject.transform.DOMoveX(-35.64F, 3);


}



