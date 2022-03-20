using UnityEngine;

public class RotationScript : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private bool notRotateChild;
    private float z;

    private void Update()
    {
        transform.rotation = Quaternion.Euler(Vector3.forward * z);
        z += 1 * speed;

        if (notRotateChild)
        {
            transform.GetChild(0).rotation = Quaternion.Euler(Vector3.forward * 0);
        }
    }
}
