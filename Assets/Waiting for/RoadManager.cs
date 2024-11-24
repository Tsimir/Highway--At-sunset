using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager: MonoBehaviour
{
    public GameObject[] roadSegments; // ������ �������� ��������� ������
    public Transform playerTransform; // ������ �� ��������� ������
    public float spawnDistance = 50f;  // ���������� �� ���������� ��������
    public float destroyDistance = 100f; // ���������� �� �������� ������� ��������

    private Transform currentSegment; // ��������� ������� ������
    private Vector3 nextSpawnPosition; // ������� ��� ���������� ��������

    void Start()
    {
        // ��������� �������� ������� ��������
        SpawnNextSegment();
    }

    void Update()
    {
        // ��������� ���������� �� ���������� ������
        if (Vector3.Distance(playerTransform.position, nextSpawnPosition) <= spawnDistance)
        {
            SpawnNextSegment();
        }

        // ��������� �������� ������ ���������
        DestroyOldSegments();
    }

    void SpawnNextSegment()
    {
        // ��������� ����� ������ ��������
        int randomIndex = Random.Range(0, roadSegments.Length);
        GameObject segmentPrefab = roadSegments[randomIndex];

        // ������� ����� �������
        GameObject newSegment = Instantiate(segmentPrefab, nextSpawnPosition, Quaternion.identity);
        currentSegment = newSegment.transform;

        // ���������� ������� ��� ���������� ������
        nextSpawnPosition = currentSegment.Find("EndPoint").position;
    }

    void DestroyOldSegments()
    {
        foreach (Transform child in transform)
        {
            if (Vector3.Distance(playerTransform.position, child.position) >= destroyDistance)
            {
                Destroy(child.gameObject);
            }
        }
    }
}