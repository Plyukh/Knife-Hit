using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private CanvasGroup[] windows;
    [SerializeField] private CanvasGroup startText;
    [SerializeField] private GameObject record;
    private bool alpha;

    void Update()
    {
        if(windows[0].alpha == 1)
        {
            if (alpha == false)
            {
                startText.alpha += 0.005f;
                if (startText.alpha == 1)
                {
                    alpha = true;
                }
            }
            else
            {
                startText.alpha -= 0.005f;
                if (startText.alpha == 0)
                {
                    alpha = false;
                }
            }
        }

        for (int i = 0; i < windows.Length; i++)
        {
            if(windows[i].alpha == 1)
            {
                for (int j = 0; j < windows[i].GetComponentsInChildren<Button>().Length; j++)
                {
                    Image button = windows[i].GetComponentsInChildren<Button>()[j].GetComponent<Image>();
                    button.raycastTarget = true;
                }
            }
            else
            {
                for (int j = 0; j < windows[i].GetComponentsInChildren<Button>().Length; j++)
                {
                    Image button = windows[i].GetComponentsInChildren<Button>()[j].GetComponent<Image>();
                    button.raycastTarget = false;
                }
            }
        }
    }

    public void Lose()
    {
        GameObject.Find("Stage").GetComponent<Stage>().ResetStages(-1);
        StartCoroutine(WindowAlpha(1,2, 0.02f));
    }

    IEnumerator WindowAlpha(int windowIndex_notVision, int windowIndex_Vision, float speed)
    {
        yield return new WaitForSeconds(0);

        windows[windowIndex_notVision].alpha -= speed;
        windows[windowIndex_Vision].alpha += speed;

        if(windows[windowIndex_Vision].alpha == 1)
        {
            if (GameObject.FindWithTag("Circle"))
            {
                Destroy(GameObject.FindWithTag("Circle").transform.parent.gameObject);
            }

            record.SetActive(true);
            StopCoroutine(WindowAlpha(windowIndex_notVision, windowIndex_Vision, speed));
        }
        else
        {
            StartCoroutine(WindowAlpha(windowIndex_notVision, windowIndex_Vision, speed));
        }
    }

    public void StartGame(int windowIndex_notVision)
    {
        GetComponent<Score>().ResetScore();
        windows[1].alpha = 1;
        windows[windowIndex_notVision].alpha = 0;
        record.SetActive(false);

        GameObject.Find("Stage").GetComponent<Stage>().NextStage();
        KnifeManager.Reload();
    }

    public void Return(int windowIndex_notVision)
    {
        StartCoroutine(WindowAlpha(windowIndex_notVision, 0, 0.02f));
    }
    public void Skins()
    {
        StartCoroutine(WindowAlpha(0, 3, 0.02f));
    }
}
