using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public AudioSource sfxSource;

    [Header("Music")]
    public AudioClip townMusic;
    public AudioClip marketMusic;
    public AudioClip fightMusic;

    [Header("SFX")]
    public AudioClip levelUpClip;
    public AudioClip slashClip;
    public AudioClip enemyDefeatedClip;
    public AudioClip buttonClickClip;

    void Start()
    {
        backgroundMusic.volume = PlayerPrefs.GetFloat("MusicVolume", 1.0f);
        sfxSource.volume = PlayerPrefs.GetFloat("SFXVolume", 1.0f);
        PlayerStats.OnLevelUp += PlayLevelUpSound;
        EnemyController.OnEnemyDefeated += PlayEnemyDefeatedSound;
        CombatSystem.OnSwordSlash += PlaySwordSlashSound;
    }

    void OnDestroy()
    {
        PlayerStats.OnLevelUp -= PlayLevelUpSound;
        EnemyController.OnEnemyDefeated -= PlayEnemyDefeatedSound;
        CombatSystem.OnSwordSlash -= PlaySwordSlashSound;
    }

    public void PlayLevelUpSound(int level)
    {
        sfxSource.PlayOneShot(levelUpClip);
    }

    public void PlaySwordSlashSound()
    {
        sfxSource.PlayOneShot(slashClip);
    }

    public void PlayEnemyDefeatedSound(int level)
    {
        sfxSource.PlayOneShot(enemyDefeatedClip);
    }

    public void PlayButtonClickSound()
    {
        sfxSource.PlayOneShot(buttonClickClip);
    }

    public void EnterMarket()
    {
        backgroundMusic.clip = marketMusic;
        backgroundMusic.Play();
    }
    
    public void EnterTown()
    {
        backgroundMusic.clip = townMusic;
        backgroundMusic.Play();
    }

    public void EnterBattle()
    {
        backgroundMusic.clip = fightMusic;
        backgroundMusic.Play();
    }
    
}
