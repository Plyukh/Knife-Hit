using UnityEngine;

public class Knife : MonoBehaviour
{
    public GameObject knifeInCircle;
    [SerializeField] GameObject dnaEffect;
    public ParticleSystemRenderer particleLose;
    private Menu menu;
    private GameObject target;
    public float speed;
    private GameObject targetRay;
    private float distance = 10;

    [SerializeField] private Color32[] colors;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Circle");
        menu = GameObject.FindGameObjectWithTag("Menu").GetComponent<Menu>();
        targetRay = transform.GetChild(0).gameObject;
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

        RaycastHit2D hit = Physics2D.Raycast(targetRay.transform.position, transform.TransformDirection(Vector2.up), distance);
        if (hit.collider != null)
        {
            if (hit.collider.tag == "Circle")
            {
                hit.collider.GetComponent<HealthScript>().ApplayDamage();
                Instantiate(knifeInCircle, new Vector3(transform.position.x, hit.collider.transform.position.y - 125, hit.collider.transform.position.z + 1), transform.rotation, hit.collider.transform);

                Vibration.Vibrate();

                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Knife")
        {
            Instantiate(particleLose, new Vector3(transform.position.x, collision.transform.position.y - 150, collision.transform.position.z), particleLose.transform.rotation, collision.transform.parent.parent);
            Vibration.Vibrate();

            menu.Lose();

            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "DNA")
        {
            int random = Random.Range(20, 51);
            menu.GetComponent<DNA>().AddDNA(random, collision.gameObject);

            Instantiate(dnaEffect, new Vector3(transform.position.x, collision.transform.position.y, collision.transform.position.z + 1), transform.rotation, collision.transform.parent);
            Destroy(collision.gameObject);
        }
    }
}
