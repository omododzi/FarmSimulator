using System.Collections.Generic;
using UnityEngine;

public class SpawnApples : MonoBehaviour
{
    [Header("Spawn Settings")]
    public List<GameObject> spawnTiles; // Тайлы, на которых будут появляться яблоки
    public GameObject applePrefab; // Префаб яблока
    public int maxApplesPerTile = 3; // Максимальное количество яблок на одном тайле
    public float spawnRadius = 1f; // Радиус разброса яблок вокруг центра тайла
    public float yOffset = 0.5f; // Смещение по высоте относительно тайла

    [Header("Apple Settings")]
    public bool randomRotation = true; // Случайный поворот яблок
    public Vector2 scaleRange = new Vector2(0.8f, 1.2f); // Диапазон случайного размера

    void Start()
    {
        SpawnApplesOnTiles();
    }

    public void SpawnApplesOnTiles()
    {
        if (spawnTiles == null || spawnTiles.Count == 0)
        {
            Debug.LogWarning("No spawn tiles assigned!");
            return;
        }

        if (applePrefab == null)
        {
            Debug.LogError("Apple prefab is not assigned!");
            return;
        }

        foreach (GameObject tile in spawnTiles)
        {
            if (tile == null) continue;

            int applesToSpawn = Random.Range(1, maxApplesPerTile + 1);
            
            for (int i = 0; i < applesToSpawn; i++)
            {
                SpawnAppleOnTile(tile);
            }
        }
    }

    private void SpawnAppleOnTile(GameObject tile)
    {
        // Случайная позиция в пределах радиуса вокруг тайла
        Vector2 randomCircle = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPosition = tile.transform.position + 
                               new Vector3(randomCircle.x, yOffset, randomCircle.y);

        // Создаем яблоко
        GameObject apple = Instantiate(applePrefab, spawnPosition, GetRandomRotation());
        
        // Устанавливаем случайный размер
        float randomScale = Random.Range(scaleRange.x, scaleRange.y);
        apple.transform.localScale = Vector3.one * randomScale;

        // Делаем яблоко дочерним объектом тайла (опционально)
        apple.transform.SetParent(tile.transform);
    }

    private Quaternion GetRandomRotation()
    {
        if (randomRotation)
        {
            return Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);
        }
        return Quaternion.identity;
    }

    // Метод для очистки всех яблок (можно вызвать при необходимости)
    public void ClearAllApples()
    {
        foreach (GameObject tile in spawnTiles)
        {
            if (tile == null) continue;

            foreach (Transform child in tile.transform)
            {
                if (child.CompareTag("Apple")) // Предполагается, что у яблок есть тег "Apple"
                {
                    Destroy(child.gameObject);
                }
            }
        }
    }
}