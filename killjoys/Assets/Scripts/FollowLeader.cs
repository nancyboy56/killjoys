
using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public enum Direction
{
    Left, Middle, Right
}
public class FollowLeader : MonoBehaviour
{

    private Queue<Vector2> path = new Queue<Vector2>();
    private Vector2 previousPosition;
    private Vector2 wayPoint;
    private Vector2 leaderPosition;
    private Vector2 currentPostion;

    private Rigidbody2D rb;
    

    public Direction dir = Direction.Left;

    private bool move = false;

    private int speed =2;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        leaderPosition = GameManager.Instance.GetPlayers()[Killjoys.PartyPoison].transform.position;
        currentPostion = transform.position;
        previousPosition = leaderPosition;

        
    }

    void Update()
    {
        if (GameManager.Instance.state.Equals(GameStates.Exploring))
        {
            leaderPosition = GameManager.Instance.GetPlayers()[Killjoys.PartyPoison].transform.position;
            currentPostion = transform.position;

            float leaderX = leaderPosition.x;
            float leaderY = leaderPosition.y;

            float x = transform.position.x;
            float y = transform.position.y;

            float preX = previousPosition.x;
            float preY = previousPosition.y;

            Vector2 different = leaderPosition - previousPosition;
            //if leader postion has changed 
            if (Math.Abs(different.x) <= 0.5 || Math.Abs(different.y) <= 0.25)
            {
                findShortPath();
                move = true;
                Debug.Log("a star");
            }


            Vector2 differentWP = wayPoint - (Vector2)transform.position;
            //if path is finished 
            if (path.Count == 0)
            {
                move = false;
                Debug.Log("dont move");
            }
            else if (Math.Abs(differentWP.x) <= 0.1 || Math.Abs(differentWP.y) <= 0.1)
            {
                findWayPoint();
                move = true;
                Debug.Log("move to next way point");
            }
            // if the player is within the current waypoint


            Debug.Log("Waypoint" + wayPoint.x + "," + wayPoint.y);
            previousPosition = leaderPosition;

            //  path = GameManager.Instance.GetShortestPath(new Vector2(2,2), new Vector2(5,5));
        }
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.Instance.state.Equals(GameStates.Exploring))
        {
            if (move)
            {

                Vector2 v = wayPoint - (Vector2)transform.position;
                rb.velocity = Vector2.ClampMagnitude(rb.velocity + v, speed);
                transform.up = rb.velocity.normalized;
            }
            else
            {
                rb.velocity = Vector2.zero;
            }
        }
      
    }



    private void findShortPath()
    {
        Vector2 end =leaderPosition;
        end.y -= 1;
        if (dir.Equals(Direction.Left))
        {
            end.x += 1;
        } else if (dir.Equals(Direction.Middle)) {

        } else if (dir.Equals(Direction.Right)){
            end.x -= 1;
        }
        path = GameManager.Instance.GetShortestPath(currentPostion, end);
        findWayPoint();
    }

    private void findWayPoint()
    {
        if((path.Count != 0))
        {
            wayPoint = path.Dequeue();
        }

    }
}
