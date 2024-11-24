using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public GameObject[] roadSegments; // Массив префабов сегментов дороги
    public Transform playerTransform; // Ссылка на трансформ игрока
    public float chunkSize = 100f; // Размер чанка
    private Dictionary<Vector3Int, GameObject> chunks = new Dictionary<Vector3Int, GameObject>();

    void Update()
    {
        Vector3Int playerChunkPos = GetChunkPosition(playerTransform.position);
        for (int x = -1; x <= 1; ++x)
        {
            for (int z = -1; z <= 1; ++z)
            {
                Vector3Int chunkPos = new Vector3Int(x, 0, z) + playerChunkPos;
                if (!chunks.ContainsKey(chunkPos))
                {
                    GenerateChunk(chunkPos);
                }
            }
        }

        foreach (var kvp in chunks)
        {
            if (Vector3Int.Distance(kvp.Key, playerChunkPos) > 1)
            {
                DestroyChunk(kvp.Value);
            }
        }
    }

    Vector3Int GetChunkPosition(Vector3 position)
    {
        return new Vector3Int(Mathf.FloorToInt(position.x / chunkSize), 0, Mathf.FloorToInt(position.z / chunkSize));
    }

    void GenerateChunk(Vector3Int pos)
    {
        GameObject chunkObj = new GameObject($"Chunk ({pos.x}, {pos.z})");
        chunkObj.transform.parent = transform;
        chunkObj.transform.position = new Vector3(pos.x * chunkSize, 0, pos.z * chunkSize);

        // Генерация содержимого чанка
        for (float x = 0; x < chunkSize; x += 10)
        {
            for (float z = 0; z < chunkSize; z += 10)
            {
                int randomIndex = Random.Range(0, roadSegments.Length);
                GameObject segmentPrefab = roadSegments[randomIndex];
                Instantiate(segmentPrefab, chunkObj.transform);
            }
        }

        chunks[pos] = chunkObj;
    }

    void DestroyChunk(GameObject chunk)
    {
        chunks.Remove(GetChunkPosition(chunk.transform.position));
        Destroy(chunk);
    }
}
