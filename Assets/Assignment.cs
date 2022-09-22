using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment : ProcessingLite.GP21
{
    
    public float circleDiam = 0.5f;
    public Vector2 stationaryCircle, circlePos;
    private float movementX = 1f;
    private Vector2 mouseDistance;
    private float xMax, xMin, yMax, yMin;
    bool mouseClick = false;

    void Start()
    {
        Application.targetFrameRate = 60;
        StrokeWeight(1f);
        //1. Draw a circle
        //Circle(5, 5, circleDiam);

        //Define boundaries
        xMax = Width - (circleDiam / 2f);
        xMin = 0 + (circleDiam / 2f);
        yMax = Height - (circleDiam / 2f);
        yMin = 0 + (circleDiam / 2f);
    }

void Update()
    {

        //2.Create new circles
        //float CircleX = MouseX;
        //float CircleY = MouseY;

        //if (Input.GetMouseButtonDown(0))
        //{
        //    Background(140);
        //    Fill(0);
        //    Circle(CircleX, CircleY, circleDiam);
        //}

        //3. Draw a line from the circle to the mouse
        //if (Input.GetMouseButton(0))
        //{
        //    Background(140);
        //    Circle(stationaryCircle.x, stationaryCircle.y, circleDiam);
        //    Line(stationaryCircle.x, stationaryCircle.y, MouseX, MouseY);
        //}

        //4. Calculate the Vector between circle and mouse
        //Vector2 circlePos = new Vector2(stationaryCircle.x, stationaryCircle.y);
        //Vector2 mousePos = new Vector2(MouseX, MouseY);

        //Vector2 mouseDistance = (mousePos - circlePos);
        //Debug.Log(mouseDistance);

        //5+6+7+8. Use this vector to give the circle direction (movement) + Limit and adjust speed + Bounce at boundaries
        {   
            //Draw scene every frame
            Background(140);
            Circle(circlePos.x, circlePos.y, circleDiam);

            //Loops if you have clicked and determines movement
            if (mouseClick)
            {
                //Bounce at boundaries
                if (circlePos.x >= xMax || circlePos.x <= xMin)
                {
                    mouseDistance.x *= -1;
                }
                if (circlePos.y >= yMax || circlePos.y <= yMin)
                {
                    mouseDistance.y *= -1;
                }

                circlePos += mouseDistance * Time.deltaTime;
                Line(circlePos.x, circlePos.y, MouseX, MouseY);
            }

            Debug.Log("Circle Position"+circlePos);

            //These if statements will trigger when you click the mouse button
            if (Input.GetMouseButtonDown(0))
            {
                mouseClick = false;
                circlePos = new Vector2(MouseX, MouseY);
            }

            else if (Input.GetMouseButton(0))
            {
                Line(circlePos.x, circlePos.y, MouseX, MouseY);
            }

            else if (Input.GetMouseButtonUp(0))
            {
                Vector2 mousePos = new Vector2(MouseX, MouseY);
                mouseDistance = (mousePos - circlePos);

                //Limit speed



                mouseClick = true;
            }
            Debug.Log("Mouse Distance"+mouseDistance);

        }

    }
}

