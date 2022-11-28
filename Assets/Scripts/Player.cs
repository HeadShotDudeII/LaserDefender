using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 5;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;
    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;

    Vector2 rawData;
    Vector2 minBounds;
    Vector2 maxBounds;


    private void Start()
    {
        IniBounds();
    }

    private void IniBounds()
    {
        Camera mainCam = Camera.main;
        minBounds = mainCam.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCam.ViewportToWorldPoint(new Vector2(1, 1));

    }

    void Update()
    {
        Move();
    }



    private void Move()
    {
        Vector2 delta = rawData * speed * Time.deltaTime;
        Vector2 newPos = new Vector2();
        newPos.x = Math.Clamp(transform.position.x + delta.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
        newPos.y = Math.Clamp(transform.position.y + delta.y, minBounds.y + paddingBottom, maxBounds.y - paddingBottom);
        transform.position = newPos;


    }

    void OnMove(InputValue action)
    {
        rawData = action.Get<Vector2>();


    }
}
