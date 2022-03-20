using UnityEngine;
using UnityEngine.UI;
using System;

public class SkinManager : MonoBehaviour
{
    [SerializeField] private GameObject skinSlot;
    [SerializeField] private static Skin[] skins;
    [SerializeField] private static bool unlockAllSkins;
    public static Skin selectSkin;

    public static Skin[] Skins
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
        skins = new Skin[Resources.FindObjectsOfTypeAll<Skin>().Length];

        for (int i = 0; i < Resources.FindObjectsOfTypeAll<Skin>().Length; i++)
        {
            skins[i] = Resources.FindObjectsOfTypeAll<Skin>()[i];
            Instantiate(skinSlot, transform);
        }

        for (int i = 0; i < skins.Length; i++)
        {
            transform.GetChild(i).GetChild(1).GetComponent<Image>().sprite = skins[i].Sprite;
        }
        selectSkin = skins[0];
    }

    private void Update()
    {
        for (int i = 0; i < skins.Length; i++)
        {
            if (!skins[i].Unlock)
            {
                transform.GetChild(i).GetChild(1).GetComponent<Image>().color = new Color32(0, 0, 0, 255);
            }
            else
            {
                transform.GetChild(i).GetChild(1).GetComponent<Image>().color = new Color32(255, 255, 255, 255);
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

    public static void UnlockSkin(int index)
    {
        skins[index].Unlock = true;
    }
}
