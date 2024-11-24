using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
    public GameObject[] environmentObjects; // Массив префабов объектов окружения
    public float spawnInterval = 40f; // Увеличенный интервал между объектами
    public int maxObjects = 60; // Увеличенное количество объектов
    private float nextSpawnTime = 0f;
    private Transform playerTransform; // Ссылка на трансформ игрока
    public float minSpawnDistance = 40f; // Минимальное расстояние для спавна объектов
    public float viewDistance = 20f; // Максимальная дистанция видимости объектов

    void Start()
    {
        playerTransform = FindObjectOfType<PlayerController>().transform;
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnEnvironmentObject();
            nextSpawnTime = Time.time + spawnInterval;
        }

        CleanUpOutOfViewObjects();
    }

    void SpawnEnvironmentObject()
    {
        // Случайный выбор объекта
        int randomIndex = Random.Range(0, environmentObjects.Length);
        GameObject objectPrefab = environmentObjects[randomIndex];

        // Спавним объект перед игроком
        Vector3 spawnPosition = playerTransform.position + playerTransform.forward * (minSpawnDistance + Random.Range(0f, viewDistance - minSpawnDistance));
        spawnPosition.x += Random.Range(-10f, 10f);
        Instantiate(objectPrefab, spawnPosition, Quaternion.Euler(0f, Random.Range(0f, 360f), 0f));
    }

    void CleanUpOutOfViewObjects()
    {
        GameObject[] objects = GameObject.FindObjectsOfType<GameObject>();
        foreach (GameObject obj in objects)
        {
            if (obj.CompareTag("EnvironmentObject") && Vector3.Distance(obj.transform.position, playerTransform.position) > viewDistance)
            {
                Destroy(obj);
            }
        }
    }
}