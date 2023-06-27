using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        upPlane();

        if (planeRB.velocity.y < -speed)
        {
            planeRB.velocity = Vector2.down * speed;
        }

    }

    private void upPlane()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            planeRB.velocity = Vector2.up * speed;
        }
    }
}
