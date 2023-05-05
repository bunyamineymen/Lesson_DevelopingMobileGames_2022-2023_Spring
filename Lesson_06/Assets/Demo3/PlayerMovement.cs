using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rgb;
    public float speed;

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        rgb.AddForce(movement * speed);

        //Debug.Log($"moveHorizontal {moveHorizontal}");
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log($"GameObject Name : {other.gameObject.name}");

        if (other.gameObject.tag == "Collectable")
        {
            other.gameObject.SetActive(false);

            ScoreManager.instance.IncreaseScore();
        }


        //if (other.gameObject.GetComponent<Collectables>())
        //{
        //    other.gameObject.SetActive(false);
        //}

    }

}
