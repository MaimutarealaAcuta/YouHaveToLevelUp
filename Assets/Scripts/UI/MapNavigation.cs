using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapNavigation : MonoBehaviour
{
    public GameObject Town;
    public GameObject Market;
    public GameObject TrainingGrounds;
    public GameObject MagicForest;
    
    void Start()
    {
        GoToTown();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToTown()
    {
        Town.SetActive(true);
        Market.SetActive(false);
        TrainingGrounds.SetActive(false);
        MagicForest.SetActive(false);
    }

    public void GoToMarket()
    {
        Town.SetActive(false);
        Market.SetActive(true);
        TrainingGrounds.SetActive(false);
        MagicForest.SetActive(false);
    }

    public void GoToTrainingGrounds()
    {
        Town.SetActive(false);
        Market.SetActive(false);
        TrainingGrounds.SetActive(true);
        MagicForest.SetActive(false);
    }

    public void GoToMagicForest()
    {
        Town.SetActive(false);
        Market.SetActive(false);
        TrainingGrounds.SetActive(false);
        MagicForest.SetActive(true);
    }
}
