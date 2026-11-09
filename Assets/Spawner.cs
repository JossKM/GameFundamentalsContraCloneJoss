//Responsible for spawning gameobjects, used in player gun, enemy gun, enemy spawner
using UnityEngine;

public class Spawner : MonoBehaviour // Class declaration 
{ //Class definition is the contents of these curly braces

    //The variables that make up data members of the class Spawner
    //Public data members can be accessed from other classes
    public GameObject prefabToSpawn; // reference type
    public float secondsPassed = 0.0f; // value type
    public float spawnIntervalSeconds = 1.0f;
    public bool isSpawning = true;

    // Update is called once per frame
    void Update()
    {
        secondsPassed += Time.deltaTime;

        if (secondsPassed > spawnIntervalSeconds && isSpawning)
        {
            Instantiate(prefabToSpawn, transform.position, transform.rotation);
            secondsPassed = 0;
        }
    }
} // End of class definition of Spawner
