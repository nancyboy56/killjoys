
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

    private int speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        leaderPosition = GameManager.Instance.GetPlayers()["Party_Poison"].transform.position;
        currentPostion = transform.position;
        previousPosition = leaderPosition;

        speed = GameManager.Instance.speed;
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
        if (!(preX <= leaderX + 0.5 && x >= preX - 0.5 && 
            preY <= leaderY + 0.5 && preY >= leaderY - 0.5))
        {
            findShortPath();
            move = true;
        }
        


        //if path is finished 
        if (path.Count == 0)
        {
            move = false;
        }
        // if the player is within the current waypoint
        if (x <= wayPoint.x + 0.5 && x >= wayPoint.x - 0.5 && 
            y <= wayPoint.y + 0.5 && y >= wayPoint.y - 0.5)
        {
            findWayPoint();
            move = true;
        }
        //if no path then do a star
        //if the leader has moved do a star
        // should the charcter move
        Debug.Log("Waypoint" + wayPoint.x + "," + wayPoint.y);
        previousPosition = leaderPosition;

        //  path = GameManager.Instance.GetShortestPath(new Vector2(2,2), new Vector2(5,5));
    }



    // Update is called once per frame
    void FixedUpdate()
    {

        if (move)
        {
            rb.MovePosition(rb.position + wayPoint.normalized * speed * Time.fixedDeltaTime);
        }
      
    }



    private void findShortPath()
    {
        Vector2 end =leaderPosition;
        end.y -= 0.5f;
        if (dir.Equals(Direction.Left))
        {
            end.x += 0.5f;
        } else if (dir.Equals(Direction.Middle)) {

        } else if (dir.Equals(Direction.Right)){
            end.x -= 0.5f;
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
