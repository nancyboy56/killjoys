using AStarSharp;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class FollowLeader : MonoBehaviour
{

    private Queue<Vector2> pathToLeader = new Queue<Vector2>();
    private Vector2 previousPosition;
    private Vector2 wayPoint;
    private Vector2 leaderPosition;

    private Rigidbody2D rb;
    private bool firstTime = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        GameManager.Instance.GetShortestPath(new Vector2(1, 1), new Vector2(5, 5));
        /*Debug.Log(previousPosition);
        Vector2 leaderPosition = GameManager.Instance.getPlayers()["Party_Poison"].transform.position;
        if (firstTime)
        {
            Debug.Log("no prev");
            FindPath();
            firstTime = false;

         }
        else if(pathToLeader.Count!=0)
        {
            Debug.Log("has prev and a path");
            if (System.Math.Floor(previousPosition.x) == System.Math.Floor(leaderPosition.x) && 
                System.Math.Floor(previousPosition.y) == System.Math.Floor(leaderPosition.y))
            {
                Debug.Log("has prev and a path and leader hasnt moved");
                if (System.Math.Floor(transform.position.x) == System.Math.Floor(wayPoint.x) &&
                System.Math.Floor(transform.position.y) == System.Math.Floor(wayPoint.y))
                {
                    Debug.Log("if way point isnt this position");
                    findWayPoint();
                }
                    
            }
            else
            {
                FindPath();
            }
        }
        
        Debug.Log("wp" + wayPoint);
       // Debug.Log("Leader postion:" + leaderPosition);
        if (!wayPoint.Equals(leaderPosition))
        {
            Debug.Log("move!!");
            Vector3 Vect = new Vector3(wayPoint.x, wayPoint.y, 0);
            //   tempVect = tempVect.normalized * GameManager.Instance.speed * Time.deltaTime;
            rb.velocity = wayPoint; 
        }*/

    }

    

    private void FindPath()
    {
        previousPosition = leaderPosition;
        pathToLeader = GameManager.Instance.GetShortestPath(transform.position, leaderPosition);
        findWayPoint();
    }

    private void findWayPoint()
    {
        while (System.Math.Floor(transform.position.x) == System.Math.Floor(wayPoint.x) &&
                System.Math.Floor(transform.position.y) == System.Math.Floor(wayPoint.y))
        {
            wayPoint = pathToLeader.Dequeue();
        }
    }
}
