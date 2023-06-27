using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObstacleController : MonoBehaviour
{
    [SerializeField] private float timer = 1f;
    [SerializeField] private GameObject obstacle;

    [SerializeField] private Vector3 positionObstacleInit;

    [SerializeField] private float maxY = 1.51f;
    [SerializeField] private float minY = -1.51f;
    
    [SerializeField] private float maxTimer = 1f;
    [SerializeField] private float minTimer = 3f;

    private float gamePoints = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        gamePoints += Time.deltaTime;

        CreateObstacle();
    }

    private void CreateObstacle()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = Random.Range(minTimer, maxTimer);

            positionObstacleInit.y = Random.Range(minY, maxY);

            Instantiate(obstacle, positionObstacleInit, Quaternion.identity);
        }
    }
}
