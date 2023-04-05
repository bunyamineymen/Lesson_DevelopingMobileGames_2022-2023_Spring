using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class SwerveMovement : MonoBehaviour
{
    [SerializeField]
    private SwerveInputSystem swerveInputSystem;



    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.IsSessionPlaying)
            return;

        float swerveAmount = Time.deltaTime * 1 * swerveInputSystem.MoveFactoryX;
        swerveAmount = Mathf.Clamp(swerveAmount, -1f, 1f);
        transform.Translate(swerveAmount, 0f, 0f);
    }
}
