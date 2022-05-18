using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Harvesting : MonoBehaviour
{
    
    public static int plants;
    public static UnityEvent OnPlantsCountChange = new UnityEvent();

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "tractor")
        {
            Destroy(gameObject);
            plants++;
            OnPlantsCountChange?.Invoke();
            //Debug.Log("Трактор вошёл");
            
        }
    }
}
