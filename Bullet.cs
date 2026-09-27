using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour{

    public float speed = 10f;
    public float maxLifeTime = 3f;
    public Vector3 targetVector;

    public GameObject SmallMeteorSpawner, Small_meteorPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, maxLifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * targetVector * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            GameObject sm1 = Instantiate(Small_meteorPrefab,SmallMeteorSpawner.transform.position, Quaternion.identity);
            GameObject sm2 = Instantiate(Small_meteorPrefab,SmallMeteorSpawner.transform.position, Quaternion.identity);
            Meteor_small meteoroScript1 = sm1.GetComponent<Meteor_small>();
            meteoroScript1.targetVector = transform.right;
            Meteor_small meteoroScript2 = sm1.GetComponent<Meteor_small>();
            meteoroScript2.targetVector = -transform.right;
            

            IncreaseScore();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "Mini_enemy")
        {
            IncreaseScore();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
    
    private void IncreaseScore()
    {
        Player.SCORE++;
        Debug.Log(Player.SCORE);
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        GameObject go = GameObject.FindGameObjectWithTag("UI");
        go.GetComponent<Text>().text = "Puntos : " + Player.SCORE;
    }
}
