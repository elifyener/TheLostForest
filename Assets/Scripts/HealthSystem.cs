using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public static int health = 3;
    private void Update() 
    {
        switch (health)
        {
            case 3:
                Debug.Log("3");
            break;
            case 2:
                Debug.Log("2");
            break;
            case 1:
                Debug.Log("1");
            break;
        }
    }
    
}
