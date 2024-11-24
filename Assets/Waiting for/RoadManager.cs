using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager: MonoBehaviour
{
    public GameObject[] roadSegments; // Массив префабов сегментов дороги
    public Transform playerTransform; // Ссылка на трансформ игрока
    public float spawnDistance = 50f;  // Расстояние до следующего сегмента
    public float destroyDistance = 100f; // Расстояние до удаления старого сегмента

    private Transform currentSegment; // Последний сегмент дороги
    private Vector3 nextSpawnPosition; // Позиция для следующего сегмента

    void Start()
    {
        // Начальное создание первого сегмента
        SpawnNextSegment();
    }

    void Update()
    {
        // Проверяем расстояние до следующего спавна
        if (Vector3.Distance(playerTransform.position, nextSpawnPosition) <= spawnDistance)
        {
            SpawnNextSegment();
        }

        // Проверяем удаление старых сегментов
        DestroyOldSegments();
    }

    void SpawnNextSegment()
    {
        // Случайный выбор нового сегмента
        int randomIndex = Random.Range(0, roadSegments.Length);
        GameObject segmentPrefab = roadSegments[randomIndex];

        // Спавним новый сегмент
        GameObject newSegment = Instantiate(segmentPrefab, nextSpawnPosition, Quaternion.identity);
        currentSegment = newSegment.transform;

        // Определяем позицию для следующего спавна
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