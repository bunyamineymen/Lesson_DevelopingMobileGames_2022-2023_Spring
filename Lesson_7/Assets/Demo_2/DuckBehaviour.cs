using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class DuckBehaviour : MonoBehaviour
{

    public Material defautMaterial;
    public Material collideMaterial;

    public MeshRenderer MeshRenderer;

    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * 100);
    }

    RaycastHit hitinfo;

    private void FixedUpdate()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 15, Color.red);

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward) * 15, out hitinfo))
        {
            if (hitinfo.transform.gameObject.CompareTag("RaycastReference"))
            {
                //Action

                StartCoroutine(RaycastAction());
            }
        }

    }

    IEnumerator RaycastAction()
    {
        MeshRenderer.material = collideMaterial;
        yield return new WaitForSeconds(1f);
        MeshRenderer.material = defautMaterial;
    }

}
