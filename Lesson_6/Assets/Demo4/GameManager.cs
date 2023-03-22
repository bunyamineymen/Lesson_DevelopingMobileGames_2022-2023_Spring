using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject Ball;
    public Transform Reference;
    public ParticleSystem ParticleSystem;

    public float velocity;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Throw();
        }
    }


    public void Throw()
    {
        ParticleSystem.Play();

        var ball = Instantiate(Ball, Reference.position, Quaternion.identity);
        var rgb = ball.GetComponent<Rigidbody>();

        float vel = UnityEngine.Random.Range(velocity - 800, velocity + 800);

        Debug.Log(vel);

        rgb.AddForce(Reference.forward * vel, ForceMode.Force);

    }

}
