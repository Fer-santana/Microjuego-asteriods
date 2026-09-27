using UnityEngine;
using UnityEngine.SceneManagement;

public class Meteor : MonoBehaviour
{
    public float speed = 10f;
    public float maxLifeTime = 3f;
    public Vector3 targetVector;

    public static float xBorderLimit, yBorderLimit;


    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        
        transform.Rotate(Vector3.forward,Random.Range(0.0f, 360.0f));
        targetVector = transform.up;
        yBorderLimit = Camera.main.orthographicSize + 1;
        xBorderLimit = (Camera.main.orthographicSize + 1) * Screen.width / Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * targetVector * Time.deltaTime);

        var newPos = transform.position;
        if(newPos.x > xBorderLimit){
            newPos.x = -xBorderLimit + 1;
            maxLifeTime--;
        }
        if(newPos.x < -xBorderLimit){
            newPos.x = xBorderLimit - 1;
            maxLifeTime--;
        }
        if(newPos.y > yBorderLimit){
            newPos.y = -yBorderLimit + 1;
            maxLifeTime--;
        }
        if(newPos.y < -yBorderLimit){
            newPos.y = yBorderLimit - 1;
            maxLifeTime--;
        }
        transform.position = newPos;
        if (maxLifeTime == 0)
        Destroy(gameObject);
    }
}

