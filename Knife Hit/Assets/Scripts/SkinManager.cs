using UnityEngine;
using UnityEngine.UI;
using System;

public class SkinManager : MonoBehaviour
{
    [SerializeField] private GameObject skinSlot;
    [SerializeField] private Skin[] skins;
    [SerializeField] private static bool unlockAllSkins;
    public Skin selectSkin;

    public Skin[] Skins
    {
        get
        {
            return skins;
        }
    }

    public static bool UnlockAllSkins
    {
        get
        {
            return unlockAllSkins;
        }
    }

    private void Awake()
    {
        selectSkin = skins[0];
    }

    private void Start()
    {
        for (int i = 0; i < skins.Length; i++)
        {
            Instantiate(skinSlot, transform);
        }

        for (int i = 0; i < skins.Length; i++)
        {
            transform.GetChild(i).GetChild(1).GetComponent<Image>().sprite = skins[i].Sprite;
            transform.GetChild(i).GetComponent<SkinSlot>().id = i;
        }
    }

    private void Update()
    {
        for (int i = 0; i < skins.Length; i++)
        {
            if (!skins[i].Unlock)
            {
                transform.GetChild(i).GetChild(1).GetComponent<Image>().color = new Color32(0, 0, 0, 255);
                transform.GetChild(i).GetComponent<Button>().interactable = false;
            }
            else
            {
                transform.GetChild(i).GetChild(1).GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                transform.GetChild(i).GetComponent<Button>().interactable = true;
            }
        }

        for (int i = 0; i < skins.Length; i++)
        {
            if(skins[i].Unlock == false)
            {
                unlockAllSkins = false;
                break;
            }
            else if(skins[skins.Length - 1].Unlock)
            {
                unlockAllSkins = true;
            }
        }
    }

    public void UnlockSkin(int index)
    {
        skins[index].Unlock = true;
        Save.SaveSkins(index);
    }
}
