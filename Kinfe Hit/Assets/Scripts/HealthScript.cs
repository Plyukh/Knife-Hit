using System.Collections;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    [SerializeField] private GameObject destroyEffect;
    [SerializeField] ParticleSystem particle;
    private SpriteRenderer hitRenderer;
    public int health;
    private int maxHealth;
    private void Start()
    {
        hitRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        for (int i = KnifeManager.knifeSlots.Length - 1; i >= 0 ; i--)
        {
            if (KnifeManager.knifeSlots[i].alpha > 0)
            {
                maxHealth += 1;
            }
        }
        health = maxHealth;
    }

    public void ApplayDamage()
    {
        health -= 1;

        hitRenderer.color = new Color32(255, 255, 255, 165);
        StartCoroutine(ColorHit(0.0001f));

        Instantiate(particle, new Vector3(transform.position.x, transform.position.y - 150, transform.position.z), transform.rotation, transform.parent);

        if (health <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        Instantiate(destroyEffect,new Vector3(transform.position.x, transform.position.y, destroyEffect.transform.position.z), destroyEffect.transform.rotation, transform.parent.parent);
        Vibration.Vibrate();

        Destroy(transform.parent.gameObject);

        GameObject.Find("Stage").GetComponent<Stage>().NextStage();
    }

    IEnumerator ColorHit(float time)
    {
        yield return new WaitForSeconds(time);
        if (hitRenderer.color.a > 0)
        {
            hitRenderer.color -= new Color32(0, 0, 0, 2);
            StartCoroutine(ColorHit(time));
        }
        else
        {
            StopCoroutine(ColorHit(time));
        }
    }
}
