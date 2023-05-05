
using UnityEngine;

public class Collectables : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.Rotate(new Vector3(13, 45, 45) * Time.deltaTime * 3);
    }
}
