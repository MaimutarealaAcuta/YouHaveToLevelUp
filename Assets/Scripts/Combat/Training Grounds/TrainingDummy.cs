using UnityEngine;
using System.Collections;

public class TrainingDummy : MonoBehaviour
{
    [SerializeField]
    private int baseExperience = 1;

    [Header("Combo resources")]
    [SerializeField]
    private AudioSource sfxSource;
    [SerializeField]
    private AudioClip slashClip;

    private PlayerStats playerStats;
    private FloatingTextController floatingTextController;
    private float hitCooldown = 0.2f; // 5 hits per second
    private bool canHit = true;

    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        floatingTextController = FindObjectOfType<FloatingTextController>();
    }

    public void HitDummy()
    {
        if (canHit)
        {
            int experienceGained = baseExperience * playerStats.level;
            playerStats.AddExperience(experienceGained);

            PlayEffects();
            ShowFloatingText(experienceGained);

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

    private void ShowFloatingText(int expAmount)
    {
        if (floatingTextController != null)
        {
            string floatingText = "+ " + expAmount.ToString() + " exp";
            floatingTextController.CreateFloatingText(floatingText);
        }
    }
}
