using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField] GameObject[] tilePrefabs;
    [SerializeField] float tileLength = 80;
    [SerializeField] int numberOfTiles = 2;
    [SerializeField] float zSpawn = 10;
    [SerializeField] Transform playerTransform;
    private List<GameObject> activeTiles = new List<GameObject>();

    void Start()
    {
        for(int i = 0; i < numberOfTiles; i++)
        {
            if (i == 0) 
                SpawnTile(0);
            else
                SpawnTile(Random.Range(0, tilePrefabs.Length));
        }
    }

    private void Update()
    {
        if (playerTransform.position.z > zSpawn - tileLength)
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
            DeleteTile();
        }
    }

    private void SpawnTile(int tileIndex)
    {
        GameObject newTile = Instantiate(tilePrefabs[tileIndex], transform.forward * zSpawn - transform.up, transform.rotation);
        activeTiles.Add(newTile);
        zSpawn += tileLength;
    }

    private void DeleteTile()
    {  
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }


}
