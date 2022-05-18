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
    [SerializeField] private Transform spawnPoint;
    [SerializeField] public enum Animals {cow, chicken, sheep}
    public List<Transform> points;

    public void Buy(int id) {
            if (Clicker.clicks >= cost[(Animals)id] && Harvesting.plants > 0) {
                Spawn((Animals)id);
                Clicker.clicks -= cost[(Animals)id];
                Clicker.Click?.Invoke();
            } 
               
    }

    private void Spawn(Animals id) {
        switch (id) {
            case Animals.cow:
                Instantiate(cow).transform.position = spawnPoint.position;
                GameObject animal = Instantiate(cow);
                animal.transform.position = spawnPoint.position;
                animal.GetComponent<AnimalMovement>().points = points;
                Clicker.coefficient += 3;
                cows++;
                cowText.text = cows.ToString();
                break;
            case Animals.chicken:
                Instantiate(chicken).transform.position = spawnPoint.position;
                GameObject animal1 = Instantiate(chicken);
                animal1.transform.position = spawnPoint.position;
                animal1.GetComponent<AnimalMovement>().points = points;
                Clicker.coefficient += 1;
                chickens++;
                chickenText.text = chickens.ToString();
                break;
            case Animals.sheep:
                Instantiate(sheep).transform.position = spawnPoint.position;
                GameObject animal2 = Instantiate(chicken);
                animal2.transform.position = spawnPoint.position;
                animal2.GetComponent<AnimalMovement>().points = points;
                Clicker.coefficient += 2;
                sheeps++;
                sheepText.text = sheeps.ToString();
                break;
        }
    }

}
