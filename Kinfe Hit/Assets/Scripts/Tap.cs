using UnityEngine;
using System.Collections;

public class Tap : MonoBehaviour
{
    [SerializeField] private GameObject knifePrefab;
    [SerializeField] private KnifeManager knifeManager;
    private AudioSource audioSource;
    public float speed;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        knifePrefab.GetComponent<Knife>().speed = speed;
    }

    private void Update()
    {
        knifePrefab.GetComponent<SpriteRenderer>().sprite = SkinManager.selectSkin.Sprite;
        knifePrefab.GetComponent<Knife>().knifeInCircle.GetComponent<SpriteRenderer>().sprite = SkinManager.selectSkin.Sprite;
        knifePrefab.GetComponent<Knife>().particleLose.material = SkinManager.selectSkin.KnifeMaterial;

        knifeManager.GetComponent<SpriteRenderer>().color += new Color32(0, 0, 0, 5);

        if (Input.GetMouseButtonDown(0))
        {
            SpawnKnife();
        }
    }

    public void SpawnKnife()
    {
        if (KnifeManager.knifeSlots[KnifeManager.knifeSlots.Length - 1].alpha > 0.25f
            && GetComponent<CanvasGroup>().alpha == 1
            && GameObject.FindWithTag("Circle") != null
            && knifeManager.CanTap)
        {
            audioSource.Play();
            knifeManager.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 0);
            Instantiate(knifePrefab, new Vector3(knifeManager.transform.position.x, knifeManager.transform.position.y, knifeManager.transform.position.z + 2), transform.rotation, knifeManager.transform.parent);
            knifeManager.Minus();
        }
    }
}
