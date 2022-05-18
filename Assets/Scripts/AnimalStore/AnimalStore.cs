using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalStore : MonoBehaviour
{
    Dictionary<Animals, int> cost = new Dictionary<Animals, int>() {
        { Animals.cow, 50 },
        { Animals.chicken, 15 },
        { Animals.sheep, 30 }


    };
    public static int chickens, sheeps, cows;
    public Text chickenText, sheepText, cowText;
    [SerializeField] private GameObject cow, sheep, chicken;
    [SerializeField] private Button cowButton, sheepButton, chickenButton;

    [SerializeField] private Transform spawnPoint;
    [SerializeField] public enum Animals { cow, chicken, sheep }
    public List<Transform> points = new List<Transform>();
    [SerializeField] private int maxCow = 5, maxSheep = 5, maxChicken = 5;

    public void Buy(int id)
    {
        if (Clicker.clicks >= cost[(Animals)id] && Harvesting.plants > 0)
        {
            Spawn((Animals)id);
            Clicker.clicks -= cost[(Animals)id];
            Clicker.Click?.Invoke();
        }

    }

    private void Spawn(Animals id)
    {
        switch (id)
        {
            case Animals.cow:
                GameObject cow = Instantiate(this.cow);
                cow.transform.position = spawnPoint.position;
                cow.GetComponent<AnimalMovement>().points.AddRange(points.ToArray());
                Clicker.coefficient += 3;
                cows++;
                if (cows >= maxCow) cowButton.interactable = false;
                cowText.text = cows.ToString();
                break;
            case Animals.chicken:
                GameObject chicken = Instantiate(this.chicken);
                chicken.transform.position = spawnPoint.position;
                chicken.GetComponent<AnimalMovement>().points.AddRange(points.ToArray());
                Clicker.coefficient += 1;
                chickens++;
                if (chickens >= maxChicken) chickenButton.interactable = false;

                chickenText.text = chickens.ToString();
                break;
            case Animals.sheep:
                GameObject sheep = Instantiate(this.sheep);
                sheep.transform.position = spawnPoint.position;
                sheep.GetComponent<AnimalMovement>().points.AddRange(points.ToArray());
                Clicker.coefficient += 2;
                sheeps++;
                if (sheeps >= maxSheep) sheepButton.interactable = false;

                sheepText.text = sheeps.ToString();
                break;
        }
    }

}
