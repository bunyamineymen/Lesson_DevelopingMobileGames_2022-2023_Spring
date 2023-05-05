using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo4 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject cloneArmature;
    public Animator cloneAnimatorController;
    public GameObject bomb;
    public float explosionForce;
    public void killClone()
    {

        cloneAnimatorController.enabled = false;
        cloneArmature.SetActive(true);
    }

    public void killCloneWithFire()
    {
        bomb.SetActive(true);
        cloneArmature.SetActive(true);
        cloneAnimatorController.enabled = false;
        invokeExplosion();
    }

    private void invokeExplosion()
    {
        Vector3 explosionPos = bomb.transform.position;

        Collider[] colliders = Physics.OverlapSphere(explosionPos, 15);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(explosionForce, explosionPos, 10, 35.0F);
        }
    }
}
