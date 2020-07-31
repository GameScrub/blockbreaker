using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    [SerializeField] private float screenWidthInUnits = 16f;
    [SerializeField] private float minPositionInUnits = 1f;
    [SerializeField] private float maxPositionInUnits = 15f;


    private GameState gameState;
    private Ball ball;

    // Start is called before the first frame update
    void Start()
    {
        gameState = FindObjectOfType<GameState>();
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePosition = new Vector2(transform.position.x, transform.position.y)
        {
            x = Mathf.Clamp(GetXPosition(), minPositionInUnits, maxPositionInUnits)
        };


        transform.position = paddlePosition;
    }

    private float GetXPosition()
    {
        if (gameState.IsAutoPlayEnabled())
        {
            return ball.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
