using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo2 : MonoBehaviour
{

    public Animator doorAnimationController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openDoor()
    {
        doorAnimationController.SetTrigger("opendoor");
    }

    public void closeDoor()
    {
        doorAnimationController.SetTrigger("closedoor");
    }
}
