using UnityEngine;

public class Circle : MonoBehaviour
{
    public float speed;
    public float interval;
    public float timeStop;

    private float timeToInterval;
    private float timeToStop;
    private float z;

    private void Update()
    {
        Rotation();
    }

    void Rotation()
    {
        if (timeToInterval >= interval && interval != 0)
        {
            z += 0 * speed;
            timeToStop += Time.deltaTime;
            if (timeToStop >= timeStop)
            {
                timeToInterval = 0;
                timeToStop = 0;
            }
        }
        else
        {
            timeToInterval += Time.deltaTime;
            transform.rotation = Quaternion.Euler(Vector3.forward * z);
            z += 1 * speed;
        }
    }
}
