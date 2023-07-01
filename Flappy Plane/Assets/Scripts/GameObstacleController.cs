using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameObstacleController : MonoBehaviour
{
    [SerializeField] private float timer = 1f;
    [SerializeField] private GameObject obstacle;

    [SerializeField] private Vector3 positionObstacleInit;

    [SerializeField] private float maxY = 1.51f;
    [SerializeField] private float minY = -1.51f;
    
    [SerializeField] private float maxTimer = 1f;
    [SerializeField] private float minTimer = 3f;

    private PlaneController plane;

    private int level;

    // Start is called before the first frame update
    void Start()
    {
        plane = FindObjectOfType<PlaneController>();
    }

    // Update is called once per frame
    void Update()
    {
        level = plane.ReturnLevel();
        CreateObstacle();
    }

    

    private void CreateObstacle()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = Random.Range(minTimer / level, maxTimer);

            positionObstacleInit.y = Random.Range(minY, maxY);

            Instantiate(obstacle, positionObstacleInit, Quaternion.identity);
        }
    }
}
