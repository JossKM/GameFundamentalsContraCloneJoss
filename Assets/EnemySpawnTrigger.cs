using UnityEngine;

public class EnemySpawnTrigger : MonoBehaviour
{
    [SerializeField]
    Spawner spawner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawner = GetComponent<Spawner>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //will be valid if it is a player, null if not a player
        if(collision.GetComponent<PlayerCharacterControls>() != null)
        {
            spawner.isSpawning = true;
            Debug.Log("Player detected!");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerCharacterControls playerReference = collision.GetComponent<PlayerCharacterControls>();
        //will be valid if it is a player, null if not a player
        if (playerReference != null)
        {
            spawner.isSpawning = false;
            Debug.Log("Player gone!");
        }
    }
}
