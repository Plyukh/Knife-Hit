using UnityEngine;
using System.Collections;

public class KnifeManager : MonoBehaviour
{
    public static CanvasGroup[] knifeSlots = new CanvasGroup[12];

    private float timeToDeley;
    public float delay;

    public bool CanTap
    {
        get
        {
            return timeToDeley >= delay;
        }
    }

    private void Awake()
    {
        for (int i = 0; i < knifeSlots.Length; i++)
        {
            knifeSlots[i] = GameObject.Find("Knifes").transform.GetChild(i).GetComponent<CanvasGroup>();
        }
    }

    private void Update()
    {
        GetComponent<SpriteRenderer>().sprite = SkinManager.selectSkin.Sprite;

        if (timeToDeley < delay)
        {
            timeToDeley += Time.deltaTime;
        }
    }

    public static void Reload()
    {
        if(Stage.currentStage == 0)
        {
            for (int i = knifeSlots.Length - 1; i >= 0; i--)
            {
                if(i > 5)
                {
                    knifeSlots[i].alpha = 1f;
                }
                else
                {
                    knifeSlots[i].alpha = 0f;
                }
            }
        }
        else if (Stage.currentStage == 1)
        {
            for (int i = knifeSlots.Length - 1; i >= 0; i--)
            {
                if (i > 3)
                {
                    knifeSlots[i].alpha = 1f;
                }
                else
                {
                    knifeSlots[i].alpha = 0f;
                }
            }
        }
        else if (Stage.currentStage == 2)
        {
            for (int i = knifeSlots.Length - 1; i >= 0; i--)
            {
                if (i > 1)
                {
                    knifeSlots[i].alpha = 1f;
                }
                else
                {
                    knifeSlots[i].alpha = 0f;
                }
            }
        }
        else if (Stage.currentStage == 3)
        {
            for (int i = knifeSlots.Length - 1; i >= 0; i--)
            {
                knifeSlots[i].alpha = 1f;
            }
        }
    }

    public void Minus()
    {
        timeToDeley = 0;
        for (int i = 0; i < knifeSlots.Length; i++)
        {
            if(knifeSlots[i].alpha > 0.25f)
            {
                knifeSlots[i].alpha = 0.25f;
                break;
            }
        }
    }
}
