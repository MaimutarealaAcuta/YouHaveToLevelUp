using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public AudioSource sfxSource;

    public AudioClip levelUpClip;
    public AudioClip enemyDefeatedClip;
    public AudioClip buttonClickClip;

    void Start()
    {
        backgroundMusic.volume = PlayerPrefs.GetFloat("MusicVolume", 1.0f);
        sfxSource.volume = PlayerPrefs.GetFloat("SFXVolume", 1.0f);
        PlayerStats.OnLevelUp += PlayLevelUpSound;
        EnemyController.OnEnemyDefeated += PlayEnemyDefeatedSound;
    }

    void OnDestroy()
    {
        PlayerStats.OnLevelUp -= PlayLevelUpSound;
        EnemyController.OnEnemyDefeated -= PlayEnemyDefeatedSound;
    }

    public void PlayLevelUpSound(int level)
    {
        sfxSource.PlayOneShot(levelUpClip);
    }

    public void PlayEnemyDefeatedSound(int enemyLevel)
    {
        sfxSource.PlayOneShot(enemyDefeatedClip);
    }

    public void PlayButtonClickSound()
    {
        sfxSource.PlayOneShot(buttonClickClip);
    }
}
