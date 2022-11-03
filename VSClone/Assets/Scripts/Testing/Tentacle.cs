using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentacle : MonoBehaviour
{
    public int tentacleLength;
    public LineRenderer lineRend;
    public Vector3[] segmentPoses;
    private Vector3[] segmentVelocity;

    public Transform targetDir;
    public float targetDistance;
    public float smoothSpeed;

    private void Start()
    {
        lineRend.positionCount = tentacleLength;
        segmentPoses = new Vector3[tentacleLength];
        segmentVelocity = new Vector3[tentacleLength];
    }

    private void Update()
    {
        segmentPoses[0] = targetDir.position;

        for (int i = 1; i < segmentPoses.Length; i++)
        {
            segmentPoses[i] = Vector3.SmoothDamp(segmentPoses[i], segmentPoses[i -1] + targetDir.right * targetDistance, ref segmentVelocity[i], smoothSpeed);
        }
        lineRend.SetPositions(segmentPoses);
    }
}
