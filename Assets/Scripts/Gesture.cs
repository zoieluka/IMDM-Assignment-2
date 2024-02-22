// IMDM Course material
// Author: Myungin Lee
// Date: Fall 2023
// This code demonstrates the general applications of landmark information
// Pose + Left, Right hand landmarks data avaiable. Facial landmark need custom work
// Landmarks label reference: 
// https://developers.google.com/mediapipe/solutions/vision/pose_landmarker
// https://developers.google.com/mediapipe/solutions/vision/hand_landmarker

using Mediapipe.Unity.Holistic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gesture : MonoBehaviour
{
    static int poseLandmark_number = 32;
    static int handLandmark_number = 20;
    // Declare landmark vectors 
    public Vector3[] pose = new Vector3[poseLandmark_number];
    public Vector3[] righthandpos = new Vector3[handLandmark_number];
    public Vector3[] lefthandpos = new Vector3[handLandmark_number];
    public GameObject[] PoseLandmarks, LeftHandLandmarks, RightHandLandmarks;

    public static Gesture gen; // singleton
    public bool drawLandmarks = false;
    public bool trigger = false;
    private float distance;
    int totalNumberofLandmark;

    //public Vector3 sphere;
    public Vector3 flower;

    //public GameObject sphereGameObject;
    public GameObject Flower;
    public Color originalColor;
    public Animator animator;

    private void Awake()
    {
       //if statement to test if the distance is less than or equal to a certain number
       // average the position of the spheres first

        if (Gesture.gen == null)
        {
            Gesture.gen = this;
        }
        totalNumberofLandmark = poseLandmark_number + handLandmark_number + handLandmark_number;
        PoseLandmarks = new GameObject[poseLandmark_number];
        LeftHandLandmarks = new GameObject[handLandmark_number];
        RightHandLandmarks = new GameObject[handLandmark_number];
    }
    // Start is called before the first frame update
    void Start()
    {
        if (drawLandmarks)
        {
            // Initiate pose landmarks as spheres
            for (int i = 0; i < poseLandmark_number; i++)
            {
                PoseLandmarks[i] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            }
            // Initiate R+L hands landmarks as spheres
            for (int i = 0; i < handLandmark_number; i++)
            {
                LeftHandLandmarks[i] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                RightHandLandmarks[i] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            }
            //assign rigid bodies to generated sphere & triggers to each of them
            //manual collider (if the finger is close to certain position, then trigger
        }

        //Renderer sphereRenderer = sphereGameObject.GetComponent<Renderer>();
        //originalColor = sphereRenderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        // Case 0. Draw holistic shape
        // Assign Pose landmarks position
        int idx = 0;
        if (drawLandmarks)
        {
            foreach (GameObject pl in PoseLandmarks)
            {
                pl.transform.transform.position = -pose[idx];
                Color customColor = new Color(idx * 10 / 255, idx * 7 / 255, idx * 3 / 255, 1); // Color of pose landmarks
                pl.GetComponent<Renderer>().material.SetColor("_Color", customColor);
                pl.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
                idx++;
            }
            // Assign Left hand landmarks position
            idx = 0;
            foreach (GameObject lhl in LeftHandLandmarks)
            {
                lhl.transform.transform.position = -lefthandpos[idx];
                Color customColor = new Color(idx * 4 / 255, idx * 15f / 255, idx * 30f / 255, 1); // Color of left hand landmarks
                lhl.GetComponent<Renderer>().material.SetColor("_Color", customColor);
                lhl.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
                idx++;
            }
            // Assign Right hand landmarks position
            idx = 0;
            foreach (GameObject rhl in RightHandLandmarks)
            {
                rhl.transform.transform.position = -righthandpos[idx];
                Color customColor = new Color(idx * 4f / 255, idx * 15f / 255, idx * 30f / 255, 1); // Color of right hand landmarks
                rhl.GetComponent<Renderer>().material.SetColor("_Color", customColor);
                rhl.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
                idx++;
            }
        }

      //averages the postion of all of the spheres in the right hand
        Vector3 averageRightHandPos = Vector3.zero;
        for (int i = 0; i < handLandmark_number; i++)
        {
            averageRightHandPos += righthandpos[i];
        }
        averageRightHandPos /= handLandmark_number;

        //averages the postion of all of the spheres in the left hand
        Vector3 averageLeftHandPos = Vector3.zero;
        for (int i = 0; i < handLandmark_number; i++)
        {
            averageLeftHandPos += lefthandpos[i];
        }
        averageLeftHandPos /= handLandmark_number;

        //calculates distance of average postion for each hand, and the sphere
        //float rightDisToSphere = Vector3.Distance(averageRightHandPos, sphere);
        //float leftDisToSphere = Vector3.Distance(averageLeftHandPos, sphere);

        //distance to flower
        float rightDisToFlower = Vector3.Distance(averageRightHandPos, flower);
        float leftDisToFlower = Vector3.Distance(averageLeftHandPos, flower);

        //debug to see distance
        //Debug.Log("Right Hand Distance to Sphere: " + rightDisToSphere);
        //Debug.Log("Left Hand Distance to Sphere: " + leftDisToSphere);

        //changes color
        /*if (rightDisToSphere >= 1 || leftDisToSphere >= 1)
        {
            Renderer sphereRenderer = sphereGameObject.GetComponent<Renderer>();
            sphereRenderer.material.color = Color.red;
        }

        else
        {
            Renderer sphereRenderer = sphereGameObject.GetComponent<Renderer>();
            sphereRenderer.material.color = originalColor;
        }*/

        //animation change
        if (rightDisToFlower <= .5 || leftDisToFlower <= .5)
        {
            //switch from idle to bloom animation
            animator.SetBool("leaveHand",false);
            animator.SetBool("waveHand",true);
        }

        else
        {
            //switch from bloom to dissipate animation, then back to idle
            animator.SetBool("waveHand",false);
            animator.SetBool("leaveHand",true);
        }
    }

}
