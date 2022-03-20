using UnityEngine;
using UnityEngine.UI;

public class SkinSlot : MonoBehaviour
{
    SkinManager skinManager;

    public int id;

    private void Awake()
    {
        skinManager = transform.parent.GetComponent<SkinManager>();
    }

    public void SelectSkin()
    {
        for (int i = 0; i < skinManager.Skins.Length; i++)
        {
            if(i != id)
            {
                transform.parent.GetChild(i).GetComponent<Image>().color = new Color32(0, 0, 0, 255);
            }
            else
            {
                transform.parent.GetChild(i).GetComponent<Image>().color = new Color32(50, 130, 50, 255);

                skinManager.selectSkin = skinManager.Skins[id];
            }
        }
    }
}
