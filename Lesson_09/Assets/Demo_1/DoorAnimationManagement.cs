using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class DoorAnimationManagement : MonoBehaviour
{
    public Animator DoorAnimation;


    public void OpenDoor()
    {
        DoorAnimation.SetTrigger("open");
    }

    public void CloseDoor()
    {
        DoorAnimation.SetTrigger("close");
    }

}
