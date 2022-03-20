using UnityEngine;

public class Background : MonoBehaviour
{
    public float duration;

    Color32 startColor = new Color32(175, 175, 100, 255);
    Color32 endColor = new Color32(175, 100, 175, 255);

    void Update()
    {
        float t = Mathf.PingPong(Time.time, duration) / duration;
        if(GetComponent<Camera>().backgroundColor.r > 100)
        {
            GetComponent<Camera>().backgroundColor = Color32.Lerp(startColor, endColor, t);
        }
        else
        {
            GetComponent<Camera>().backgroundColor = Color32.Lerp(endColor, startColor, t);
        }
    }
}
