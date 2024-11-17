using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieSpawner : MonoBehaviour
{
    public GameObject piePrefab; // Assign the pie prefab in the inspector
    public Transform gridParent; // Assign the parent object of the grid in the inspector
    public float speed = 5f; // Speed of the moving pie

    private GameObject movingPie = null;
    private Vector3 targetPosition;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Trigger a new pie spawn
        {
            SpawnPie();
        }

        if (movingPie != null)
        {
            MovePieToTarget();
        }
    }

    void SpawnPie()
    {
        int randomIndex = Random.Range(0, gridParent.childCount);
        Transform spawnPoint = gridParent.GetChild(randomIndex);

        if (movingPie == null)
        {
            movingPie = Instantiate(piePrefab, spawnPoint.position, Quaternion.identity);
            targetPosition = FindNearestEmptyGrid(movingPie.transform.position);
        }
    }

    void MovePieToTarget()
    {
        if (Vector3.Distance(movingPie.transform.position, targetPosition) > 0.01f)
        {
            movingPie.transform.position = Vector3.MoveTowards(movingPie.transform.position, targetPosition, speed * Time.deltaTime);
        }
        else
        {
            movingPie = null; // Reset the moving pie after it reaches the target
        }
    }

    Vector3 FindNearestEmptyGrid(Vector3 currentPosition)
    {
        float minDistance = float.MaxValue;
        Vector3 nearestPosition = currentPosition;

        foreach (Transform child in gridParent)
        {
            if (child.childCount == 0) // Check if the grid is empty
            {
                float distance = Vector3.Distance(currentPosition, child.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestPosition = child.position;
                }
            }
        }

        return nearestPosition;
    }
}