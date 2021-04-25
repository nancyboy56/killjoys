using AStarSharp;
using System.Collections;
using System.Collections.Generic;

using System.Threading;
using UnityEditor.Timeline;
using UnityEngine;

public enum Direction
{
    Left, Middle, Right
}
public class FollowLeader : MonoBehaviour
{

    private Queue<Vector2> pathToLeader = new Queue<Vector2>();
    private Vector2 previousPosition;
    private Vector2 wayPoint;
    private Vector2 leaderPosition;
    private Vector2 currentPostion;

    private Rigidbody2D rb;
    private bool firstTime = true;

    public Direction dir = Direction.Left;

    private bool move = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        leaderPosition = GameManager.Instance.GetPlayers()["Party_Poison"].transform.position;
        currentPostion = transform.position;
        previousPosition = leaderPosition;
    }

    void Update()
    {
        leaderPosition = GameManager.Instance.GetPlayers()["Party_Poison"].transform.position;
        currentPostion = transform.position;

        float leaderX = leaderPosition.x;
        float leaderY = leaderPosition.y;

        float x = transform.position.x;
        float y = transform.position.y;

        float preX = previousPosition.x;
        float preY = previousPosition.y;


        //if leader postion has changed 
        if (!(preX <= leaderX + 1 && x >= preX - 1 && preY <= leaderY + 1 && preY >= leaderY - 1))
        {
            findShortPath();
            move = true;
        }

        // if the player is it 
        if (x <= wayPoint.x + 0.5 && x >= wayPoint.x - 0.5 && y <= wayPoint.y + 0.5 && y >= wayPoint.y - 0.5)
        {

        }


            //if no path then do a star
            //if the leader has moved do a star
            // should the charcter move

            previousPosition = leaderPosition;
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log("wowow");

        //GameManager.Instance.GetShortestPath(new Vector2(1, 1), new Vector2(5, 5));
        //Debug.Log("prev:" + previousPosition);
        leaderPosition = GameManager.Instance.GetPlayers()["Party_Poison"].transform.position;
        currentPostion = transform.position;

        float leaderX = leaderPosition.x;
        float leaderY = leaderPosition.y;
        float x = transform.position.x;
        float y = transform.position.y;

        if (firstTime)
        {
            //Debug.Log("no prev");
            StartCoroutine("FindPath");
            firstTime = false;

        }

        if (!(x <= leaderX + 1 && x >= leaderX - 1 && y <= leaderY + 1 && y >= leaderY - 1))
        {
           
             if (pathToLeader.Count != 0)
            {
                //Debug.Log("has prev and a path");

                // and the charcater is near the way point
                if (x <= wayPoint.x + 0.5 && x >= wayPoint.x - 0.5 && y <= wayPoint.y + 0.5 && y >= wayPoint.y - 0.5)
                {
                    //Debug.Log("if way point isnt this position");
                    FindPath();
                }
                // if the leader hasnt moved 
                 else if (System.Math.Floor(previousPosition.x) == System.Math.Floor(leaderPosition.x) &&
                    System.Math.Floor(previousPosition.y) == System.Math.Floor(leaderPosition.y))
                {
                    //Debug.Log("has prev and a path and leader hasnt moved");
                    FindPath();

                }
                else
                {
                    //Debug.Log("find path again");
                    FindPath();
                }
            }
            else
            {
                FindPath();
            }

            Debug.Log("wp: " + wayPoint);
            // Debug.Log("Leader postion:" + leaderPosition);
            if (!wayPoint.Equals(leaderPosition))
            {
               // Debug.Log("move!!");
                // Vector3 Vect = new Vector3(wayPoint.x, wayPoint.y, 0);
                //   tempVect = tempVect.normalized * GameManager.Instance.speed * Time.deltaTime;
                Vector2 v = wayPoint - (Vector2)transform.position;
                rb.velocity = v;
            }

        }
        else
        {
            // Debug.Log("dont move");
            
            rb.velocity = Vector2.zero;

        }


       

    }



    private void FindPath()
    {
        //previousPosition = leaderPosition;

        
       /* Thread thread1 = new Thread(findShortPath);
        thread1.Start();
        findWayPoint();*/
    }

    private void findShortPath()
    {
        Vector2 newEnd =leaderPosition;
        newEnd.y -= 0.5f;
        if (dir.Equals(Direction.Left))
        {
           
        } else if (dir.Equals(Direction.Middle)) {

        } else if (dir.Equals(Direction.Right)){

        }
        pathToLeader = GameManager.Instance.GetShortestPath(currentPostion, leaderPosition);
    }

    private void findWayPoint()
    {
        if((pathToLeader.Count != 0))
        {
            wayPoint = pathToLeader.Dequeue();
        }

    }
}
