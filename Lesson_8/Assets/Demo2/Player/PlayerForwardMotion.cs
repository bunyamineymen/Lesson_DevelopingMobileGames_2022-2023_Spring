using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerForwardMotion : MonoBehaviour
{

    public float leftBound;
    public float rightBound;


    [SerializeField]
    private float velocityOfPlayer;

    private void FixedUpdate()
    {
        if (!GameManager.instance.IsSessionPlaying)
            return;

        transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime * velocityOfPlayer;


        if (transform.position.x < leftBound)
        {
            transform.position = new Vector3(leftBound, transform.position.y, transform.position.z);
        }

        if (transform.position.x > rightBound)
        {
            transform.position = new Vector3(rightBound, transform.position.y, transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.CompareTag("FinalZone"))
        {
            DelegateStore.GameStateChange?.Invoke(GameState.MainMenu);
        }
    }

}
