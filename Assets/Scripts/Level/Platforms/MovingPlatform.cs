using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private float speed = 2f;
    public Transform[] pointsArray;
    private int i;

    private void Start()
    {
        transform.position = pointsArray[Random.Range(0, pointsArray.Length)].position;
    }

    private void Update()
    {
        if(Vector2.Distance(transform.position, pointsArray[i].position) < 0.02f)
        {
            i++;
            if(i == pointsArray.Length)
            {
                i = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, pointsArray[i].position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
