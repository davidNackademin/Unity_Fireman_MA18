using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperController : MonoBehaviour
{
    [SerializeField]
    private List<Transform> positions = new List<Transform>();
    int currentPosition = 0;
    float lastMoveTime;
    float moveDelay = 1.0f;
    

    private void Start()
    {
        transform.position = positions[currentPosition].position;
        lastMoveTime = Time.time;

        StartCoroutine(Move());
    }

    //private void Update()
    //{
    //    if( Time.time > lastMoveTime + moveDelay)
    //    {
    //        MoveToNextPosition();
    //        lastMoveTime = Time.time;
    //    }
    //}

    IEnumerator Move()
    {
        while (true)
        {
            yield return new WaitForSeconds(moveDelay);
            MoveToNextPosition();
        }
    }



    void MoveToNextPosition()
    {
        currentPosition++;

        if (currentPosition >= positions.Count)
        {
            currentPosition = 0;
        }

        transform.position = positions[currentPosition].position;
    }

}
