using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{

    [SerializeField] private float speed = 4f;

    [SerializeField] private GameObject me;

    private PlaneController plane;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(me, 5f);
    
        plane = FindObjectOfType<PlaneController>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * speed;

        speed = 4f + plane.ReturnLevel();

    }
}
