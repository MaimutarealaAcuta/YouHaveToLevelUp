using UnityEngine;
using System.Collections;

public class TrainingDummy : MonoBehaviour
{
    public int baseExperience = 1;
    public GameObject[] slashEffects;
    public Transform slashEffectContainer;

    [Header("Combo resources")]
    [SerializeField]
    private AudioSource sfxSource;
    [SerializeField]
    private AudioClip slashClip;

    private PlayerStats playerStats;
    private FloatingTextController floatingTextController;
    private float hitCooldown = 0.2f; // 5 hits per second
    private bool canHit = true;
    private Camera mainCamera;

    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        floatingTextController = FindObjectOfType<FloatingTextController>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canHit)
        {
            RegisterHit();
        }
    }

    void RegisterHit()
    {
        Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, 0);

        if (hit.collider != null && hit.collider.gameObject == gameObject)
        {
            int experienceGained = baseExperience * playerStats.level;
            playerStats.AddExperience(experienceGained);

            PlayEffects();
            ShowFloatingText(mousePosition, experienceGained);

            StartCoroutine(HitCooldown());
        }
    }

    IEnumerator HitCooldown()
    {
        canHit = false;
        yield return new WaitForSeconds(hitCooldown);
        canHit = true;
    }

    void PlayEffects()
    {
        //int randomIndex = Random.Range(0, slashEffects.Length);
        //GameObject slashEffect = Instantiate(slashEffects[randomIndex], transform.position, Quaternion.identity, slashEffectContainer);
        //Destroy(slashEffect, 0.5f);

        sfxSource.PlayOneShot(slashClip);
    }

    private void ShowFloatingText(Vector2 textPosition, int expAmount)
    {
        if (floatingTextController != null)
        {
            string floatingText = "+ " + expAmount.ToString() + " exp";
            floatingTextController.CreateFloatingText(textPosition, floatingText);
        }
    }
}
