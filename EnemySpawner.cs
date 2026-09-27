using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{

    public GameObject asteriodPrefab;
    public float spawnRatePerMinute = 5f;
    public float spawnRateIncrement = 0.5f;
    public float xlimit;
    public float maxTimeLife = 4f;

    private float spawnNext = 0;


    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawnNext){
            spawnNext = Time.time + 60 / spawnRatePerMinute;

            spawnRatePerMinute += spawnRateIncrement;

            float rand = Random.Range(-xlimit+1, xlimit-1);

            Vector2 spawnPosition = new Vector2(rand , Camera.main.orthographicSize + 1);

            GameObject meteor =Instantiate(asteriodPrefab, spawnPosition,Quaternion.identity);
        }
    }
}
