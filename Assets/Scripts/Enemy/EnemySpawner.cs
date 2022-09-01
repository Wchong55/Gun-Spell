using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //Start of spawning
    public GameObject enemy;
    public Terrain terrain;

    [SerializeField] private int maxEnemies = 5;
    public List<GameObject> enemies = new List<GameObject>();

    private float terrainWidth;
    private float terrainLength;

    private float xTerrainPos;
    private float zTerrainPos;

    public float yOffset = 0.5f;

    void Awake()
    {
        terrainWidth = terrain.terrainData.size.x;
        terrainLength = terrain.terrainData.size.z;

        xTerrainPos = terrain.transform.position.x;
        zTerrainPos = terrain.transform.position.z;
    }

    void Start()
    {
        for (int i = enemies.Count; i < maxEnemies; i++) Spawn();
    }

    void Update()
    {
        for (int i = enemies.Count; i < maxEnemies; i++) Spawn();   //Spawn if not at 5 enemies on the field
    }

    private void Spawn()
    {
        float randX = UnityEngine.Random.Range(xTerrainPos, xTerrainPos + terrainWidth);
        float randZ = UnityEngine.Random.Range(zTerrainPos, zTerrainPos + terrainLength);
        float yVal = Terrain.activeTerrain.SampleHeight(new Vector3(randX, 0, randZ));

        /*while ((randX <= 35 && randX <= 65) || (randZ >= 35 && randZ <= 65))
        {
            randX = UnityEngine.Random.Range(xTerrainPos, xTerrainPos + terrainWidth);
            randZ = UnityEngine.Random.Range(zTerrainPos, zTerrainPos + terrainLength);
        }*/

        //Apply Offset if needed
        yVal = yVal + yOffset;

        //Generate the Prefab on the generated position
        //GameObject objInst = (GameObject)Instantiate(enemy, new Vector3(randX, yVal, randZ), Quaternion.identity);
        enemies.Add(Instantiate(enemy, new Vector3(randX, yVal, randZ), Quaternion.identity));

    }
}
