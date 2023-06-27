using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaneController : MonoBehaviour
{
    private Rigidbody2D planeRB;

    [SerializeField] private float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        planeRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        UpPlane();
        LimitSpeed();

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
        if (Input.GetKeyDown(KeyCode.Space) && transform.position.y < 4.215f)
        {
            planeRB.velocity = Vector2.up * speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(0);
    }
}
