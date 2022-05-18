using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIcontroller : MonoBehaviour
{
    [SerializeField]
    private GameObject tractor;
    [SerializeField]
    private GameObject clickText, camera2, animalCamera;
    [SerializeField]
    private GameObject storePanel, tractorPanel, mainPanel, houseUI;
    public static Mode mode;
    [SerializeField] private Text textOfPlants;

    private void Awake()
    {
        Harvesting.OnPlantsCountChange.AddListener(() => { textOfPlants.text = Harvesting.plants.ToString(); });
    }

    private void Start()
    {
        ChangeMode(1);
        
    }
    public void ChangeMode(int id)
    {
        mode = (Mode)id;
        mainPanel.SetActive(false);
        camera2.SetActive(false);
        clickText.SetActive(false);
        tractor.SetActive(false);
        tractorPanel.SetActive(false);
        storePanel.SetActive(false);
        animalCamera.SetActive(false);
        houseUI.SetActive(false);
        switch (id) {
            case (int)Mode.ClickerMode:
                mainPanel.SetActive(true);
                camera2.SetActive(true);
                clickText.SetActive(true);
                houseUI.SetActive(true);
                break;
            case (int)Mode.TractorMode:
                clickText.SetActive(true);
                tractor.SetActive(true);
                tractorPanel.SetActive(true);
                break;
            case (int)Mode.StoreMode:
                clickText.SetActive(true);
                animalCamera.SetActive(true);
                storePanel.SetActive(true);
                
                break;
        }
        
        
        //if (mode == Mode.ClickerMode)
        //{
        //    mode = Mode.TractorMode;
        //    forwardButton.SetActive(true);
        //    tractor.SetActive(true);
        //    joysticks.SetActive(true);
        //    camera2.SetActive(false);
        //    clickText.SetActive(false);
        //}
        //else if (mode == Mode.TractorMode)
        //{
        //    mode = Mode.ClickerMode;
        //    forwardButton.SetActive(false);
        //    tractor.SetActive(false);
        //    joysticks.SetActive(false);
        //    camera2.SetActive(true);
        //    clickText.SetActive(true);
        //}
        //else {
        //    mode = Mode.TractorMode;
        //    forwardButton.SetActive(true);
        //    tractor.SetActive(true);
        //    joysticks.SetActive(true);
        //    camera2.SetActive(false);
        //    clickText.SetActive(false);
        //}
    }

    public enum Mode 
    { 
        TractorMode, ClickerMode, StoreMode
    }
}

