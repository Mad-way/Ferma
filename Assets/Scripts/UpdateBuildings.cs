using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class BuildingState
{
    //public int level;
    public int clicks;
    public GameObject gameObject;
    


}
public class UpdateBuildings : MonoBehaviour
{
    
    [SerializeField] private int currentLevel;
    [SerializeField] private List<BuildingState> states = new List<BuildingState>();
    [SerializeField] private Button updateButton;
    [SerializeField] private Text textOfLevel;

    void Awake()
    {
        Clicker.Click.AddListener(() => CheckLevel());
        for (int i = 1; i < states.Count; i++)
        {
            states[i].gameObject.SetActive(false);
        }
        states[0].gameObject.SetActive(true);
        CheckLevel();

    }
    void CheckLevel()
    {
        if (currentLevel >= states.Count-1)
        {
            textOfLevel.text = "Текущий уровень: " + currentLevel + "\nДостигнут максимальный уровень";
            updateButton.interactable = false;
            return;
        }
        
        if (states[currentLevel + 1].clicks <= Clicker.clicks)
        {
            updateButton.interactable = true;
        }
        else
        {
            updateButton.interactable = false;
        }
        ShowInfo();
    }
    public void UpdateBuilding()
    {
        if (states[currentLevel + 1].clicks <= Clicker.clicks)
        {
            for (int i = 0; i < states.Count; i++)
            {
                states[i].gameObject.SetActive(false);
            }
            currentLevel++;
            states[currentLevel].gameObject.SetActive(true);
            Clicker.clicks -= states[currentLevel].clicks;
            Clicker.autoCoefficient += 3;
            Clicker.Click?.Invoke();
        }
    }
    void ShowInfo() {
        if (currentLevel < states.Count-1)
            textOfLevel.text = "Текущий уровень: " + currentLevel + "\nНеобходимое кол-во кликов: " + states[currentLevel + 1].clicks;
        else textOfLevel.text = "Текущий уровень: " + currentLevel + "\nДостигнут максимальный уровень";
    }

    public void OnMouseDown()
    {
        if (UIcontroller.mode == UIcontroller.Mode.ClickerMode)
        {
            if (Harvesting.plants > 0)
            {
                Clicker.clicks += Clicker.coefficient;
                Harvesting.plants -= 1;
                Harvesting.OnPlantsCountChange?.Invoke();
            }
            else {
                Clicker.clicks++;
            }
            Clicker.Click?.Invoke();
        }
    }

     //Звук клика улучшения
    public void PlayAudio(AudioClip clip)
    {
        GetComponent<AudioSource>().PlayOneShot(clip);
    }

}
