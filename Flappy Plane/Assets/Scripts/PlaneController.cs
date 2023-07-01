using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlaneController : MonoBehaviour
{
    private Rigidbody2D planeRB;
    [SerializeField] private GameObject smoke;
    [SerializeField] private AudioClip soundLevel;
    private Vector3 camPosition;

    [SerializeField] private float speed = 5f;
    [SerializeField] private Text textLevel;
    [SerializeField] private Text textPoint;
    [SerializeField] private float NextLevel = 10f;

    private int level = 1;
    private float gamePoints = 0f;
    private Vector3 smokePosition;



    // Start is called before the first frame update
    void Start()
    {
        planeRB = GetComponent<Rigidbody2D>();
        camPosition = Camera.main.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        UpPlane();
        LimitSpeed();
        handleGameOver();
        UpLevel();

    }

    private void LimitSpeed()
    {
        if (planeRB.velocity.y < -speed)
        {
            planeRB.velocity = Vector2.down * speed;
        }
    }

    private void UpPlane()
    {
        smokePosition = transform.position;
        smokePosition.x += -0.4f;

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && transform.position.y < 4.215f)
        {
            planeRB.velocity = Vector2.up * speed;
            GameObject renderSmoke =  Instantiate(smoke, smokePosition, Quaternion.identity);

            Destroy(renderSmoke, 2f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name != "Count")
        {
            SceneManager.LoadScene(0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HandlePoints();
    }

    private void HandlePoints()
    {
        gamePoints++;

        textPoint.text = $"Pontos : {Mathf.Round(gamePoints)}";
    }

    private void handleGameOver()
    {
        if(transform.position.y < -4.22)
        {
            SceneManager.LoadScene(0);
        }
    }

    private void UpLevel()
    {
        textLevel.text = $"Level : {level}";

        if(gamePoints >= NextLevel)
        {
            AudioSource.PlayClipAtPoint(soundLevel, camPosition);
            level++;
            NextLevel *= 2;
        }
    }

    public int ReturnLevel()
    {
        return level;
    }
}
