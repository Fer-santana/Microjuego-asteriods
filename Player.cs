using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float thrustForce = 100f;
    public float rotationSpeed = 120f;

    public GameObject gun, bulletPrefab;

    private Rigidbody _rigid;

    public static int SCORE = 0;

    public static float xBorderLimit, yBorderLimit;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       _rigid = GetComponent<Rigidbody>(); 

       yBorderLimit = Camera.main.orthographicSize + 1;
       xBorderLimit = (Camera.main.orthographicSize + 1) * Screen.width / Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        var newPos = transform.position;
        if(newPos.x > xBorderLimit)
            newPos.x = -xBorderLimit + 1;
        else if(newPos.x < -xBorderLimit)
            newPos.x = xBorderLimit - 1;
        else if(newPos.y > yBorderLimit)
            newPos.y = -yBorderLimit + 1;
        else if(newPos.y < -yBorderLimit)
            newPos.y = yBorderLimit - 1;
        transform.position = newPos;


        float rotation = Input.GetAxis("Rotate") * Time.deltaTime;
        float thrust = Input.GetAxis("Thrust") * Time.deltaTime;

        Vector3 thrustDirection = transform.right;

        _rigid.AddForce(thrustForce * thrustDirection * thrust);

        transform.Rotate(Vector3.forward, rotation * rotationSpeed);

        if(Input.GetKeyDown(KeyCode.Space)){
            GameObject bullet = Instantiate(bulletPrefab, gun.transform.position, Quaternion.identity);

            Bullet balaScript = bullet.GetComponent<Bullet>();
            balaScript.targetVector = transform.right;
        }
    }


    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Mini_enemy"){
            SCORE = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            Debug.Log("He colisionado con otra cosa");
        }
    }
}