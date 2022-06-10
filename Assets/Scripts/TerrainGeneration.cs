using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGeneration : MonoBehaviour
{
    [Header("Tile Atlas")]
    public TileAtlas tileAtlas;
    
    [Header("Generation Settings")]
    public int chunkSize = 10;
    public int worldSize = 100;
    public float surfaceValue = 0.02f; 
    public Texture2D caveNoiseTexture;

    [Header("Noise Settings")]
    public float caveFreq = 0.05f;
    public float seed;

    [Header("Ore Settings")]
    public float ironRarity;
    public float ironSize;
    public Texture2D ironSpread;



    private GameObject[] worldChunks;

    private List<Vector2> worldTiles = new List<Vector2>();
    private List<GameObject> worldTileObjects = new List<GameObject>();

    private void OnValidate()
    {
        if (caveNoiseTexture == null)
        {
            caveNoiseTexture = new Texture2D(worldSize, worldSize);
            ironSpread = new Texture2D(worldSize, worldSize);

        }
        GenerateNoiseTexture(caveFreq, surfaceValue, caveNoiseTexture);
        //ores
        GenerateNoiseTexture(ironRarity, ironSize, ironSpread);
    }
    private void Start()
    {
        if (caveNoiseTexture == null)
        {
            caveNoiseTexture = new Texture2D(worldSize, worldSize);
            ironSpread = new Texture2D(worldSize, worldSize);

        }
        seed = Random.Range(-10000, 10000);
        GenerateNoiseTexture(caveFreq, surfaceValue, caveNoiseTexture);
        //ores
        GenerateNoiseTexture(ironRarity, ironSize, ironSpread);
        CreateChunks();
        GenerateTerrain();
    }
    public void CreateChunks()
    {
        int numChunks = worldSize / chunkSize;
        worldChunks = new GameObject[numChunks];
        for (int i = 0; i < numChunks; i++)
        {
            GameObject newChunk = new GameObject();
            newChunk.name = i.ToString();
            newChunk.transform.parent = this.transform;
            worldChunks[i] = newChunk;
        }
    }
    public void GenerateTerrain()
    {
        for (int x = 0; x < worldSize; x++)
        {
            for (int y = 0; y < worldSize; y++)
            {
                Sprite tileSprite;
                if (caveNoiseTexture.GetPixel(x, y).r > surfaceValue)
                {

                    if (y > 98)
                    {
                        tileSprite = tileAtlas.dirt.tileSprite;
                    }
                    else
                    {
                        if(ironSpread.GetPixel(x,y).r > 0.5f)
                            tileSprite = tileAtlas.iron.tileSprite;
                        else
                         tileSprite = tileAtlas.stone.tileSprite;
                    }
                    PlaceTile(tileSprite,x,y);

                }
                
            }
        }
    }
    public void RemoveTile(int x, int y)
    {
        if (worldTiles.Contains(new Vector2Int(x, y)) && x >= 0 && x <= worldSize && y <= worldSize)
        {
            GameObject.Destroy(worldTileObjects[worldTiles.IndexOf(new Vector2(x, y))]);
        }
    }
    public void PlaceTile(Sprite tileSprite,int x, int y)
    {
        GameObject newTile = new GameObject();

        int chunkCoord = (Mathf.RoundToInt(x / chunkSize) * chunkSize);
        chunkCoord /= chunkSize;
        newTile.transform.parent = worldChunks[(int)chunkCoord].transform;

        
        newTile.AddComponent<SpriteRenderer>();
        newTile.AddComponent<BoxCollider2D>();
        newTile.GetComponent<BoxCollider2D>().size = Vector2.one;
        newTile.tag = "Ground";
        newTile.GetComponent<SpriteRenderer>().sprite = tileSprite;
        newTile.name = tileSprite.name;
        newTile.transform.position = new Vector2(x + 0.5f, y + 0.5f);

        worldTiles.Add(newTile.transform.position - (Vector3.one * 0.5f));
        worldTileObjects.Add(newTile);
    }
    public void GenerateNoiseTexture(float frequency, float limit, Texture2D noiseTexture)
    {
        
        for (int x = 0; x < noiseTexture.width; x++)
        {
            for (int y = 0; y < noiseTexture.height; y++)
            {
                float v = Mathf.PerlinNoise((x+seed) * frequency, (y + seed) * frequency);
                noiseTexture.SetPixel(x, y, new Color(v, v, v));
                if (v > limit)
                    noiseTexture.SetPixel(x, y, Color.white);
                else
                    noiseTexture.SetPixel(x, y, Color.black);
            }
        }
        noiseTexture.Apply();
       
    }
}
