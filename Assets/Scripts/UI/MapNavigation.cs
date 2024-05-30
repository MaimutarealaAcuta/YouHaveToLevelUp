using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapNavigation : MonoBehaviour
{
    public GameObject Town;
    public GameObject Market;
    public GameObject TrainingGrounds;
    public GameObject MagicForest;


    private SoundManager soundManager;
    
    void Start()
    {
        GameEvents.OnGameStart += StartGame;

        soundManager = FindObjectOfType<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void StartGame()
    {
        GoToTown();
        GameEvents.OnGameStart -= StartGame;
    }

    public void GoToTown()
    {
        Town.SetActive(true);
        Market.SetActive(false);
        TrainingGrounds.SetActive(false);
        MagicForest.SetActive(false);

        soundManager.EnterTown();
    }

    public void GoToMarket()
    {
        Town.SetActive(false);
        Market.SetActive(true);
        TrainingGrounds.SetActive(false);
        MagicForest.SetActive(false);

        soundManager.EnterMarket();
    }

    public void GoToTrainingGrounds()
    {
        Town.SetActive(false);
        Market.SetActive(false);
        TrainingGrounds.SetActive(true);
        MagicForest.SetActive(false);

        soundManager.EnterBattle();
    }

    public void GoToMagicForest()
    {
        Town.SetActive(false);
        Market.SetActive(false);
        TrainingGrounds.SetActive(false);
        MagicForest.SetActive(true);
        
        soundManager.EnterBattle();
    }
}
