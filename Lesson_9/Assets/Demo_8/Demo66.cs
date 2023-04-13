using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo66 : MonoBehaviour
{
    public GameObject bomb;
    public GameObject ragdoll;
    public float bombRadius = 5.0F;
    public float bombPower = 400.0F;
    public float bombModifier = 3.0F;
    public bool slowMotion = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (slowMotion)
            Time.timeScale = 0.5F;
        else
            Time.timeScale = 1;
        if (Input.GetKeyDown("space"))
        {
            explode();
        }
    }

    void explode()
    {

        GameObject bombMuzzle = bomb.transform.GetChild(0).gameObject;
        GameObject ragdollArmature = ragdoll.transform.GetChild(0).gameObject;
        

        bombMuzzle.transform.SetParent(this.gameObject.transform);
        bombMuzzle.SetActive(true);
        ragdollArmature.SetActive(true);

        Vector3 explosionPos = bomb.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, bombRadius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(bombPower, explosionPos, bombRadius, bombModifier);
        }
        bomb.SetActive(false);
    }
}
