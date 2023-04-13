using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo3 : MonoBehaviour
{

    public Animator animationController;

    public bool ikActive = false;
    public Transform rightHandObj = null;
    public Transform lookObj = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



   

    void OnAnimatorIK()
    {
        if (ikActive)
        {

            // Set the look target position, if one has been assigned
            if (lookObj != null)
            {
                animationController.SetLookAtWeight(1);
                animationController.SetLookAtPosition(lookObj.position);
            }

            // Set the right hand target position and rotation, if one has been assigned
            if (rightHandObj != null)
            {
                animationController.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                animationController.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
                animationController.SetIKPosition(AvatarIKGoal.RightHand, rightHandObj.position);
                animationController.SetIKRotation(AvatarIKGoal.RightHand, rightHandObj.rotation);
            }

        }

        //if the IK is not active, set the position and rotation of the hand and head back to the original position
        else
        {
            animationController.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
            animationController.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
            animationController.SetLookAtWeight(0);
        }
    }


}
