using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperController : MonoBehaviour
{
    [SerializeField]
    private List<Transform> positions = new List<Transform>();
    public int currentPosition = 0;
    float lastMoveTime;
    float moveDelay = 1.0f;
    float deathDelay = 0.5f;

    [HideInInspector]
	public GameManager gameManager;

    private bool dead = false;

    public LayerMask layerMask;

    private void Start()
    {
        UpdatePosition();
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
        while (!dead)
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
            DestroyJumper();
        }
        else
        {
            UpdatePosition();
        }

    }

    void UpdatePosition()
    {
        transform.position = positions[currentPosition].position;
        if(positions[currentPosition].gameObject.tag == "DangerPosition")
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position,  Vector2.down,
                                                    Mathf.Infinity, layerMask);
            //om ingen fireman finns under oss
            if( hit.collider == null)
            {
                StartCoroutine( Crash() );
				gameManager.JumperCrashed();
            }
            else
            {
				gameManager.JumperSaved();
            }

        }
    }

    IEnumerator Crash()
    {
        dead = true;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.red;

        yield return new WaitForSeconds(deathDelay);
        DestroyJumper();
    }


    void DestroyJumper()
    {
        GameObject parent = transform.parent.gameObject;
        Destroy(parent);
    }


}
