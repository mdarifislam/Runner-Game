using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InfiniteRunner
{
    public class TileManager : MonoBehaviour {

        public GameObject[] tiles;
        private Transform playerTransform;
        private float spawnPointZ = -4.0f;
        private float tileLength = 8.0f;
        private float safeZone = 8.0f;
        private int amountOfTilesOnScreen = 20;
        private int lastGameObjectIndex = 0;
        private List<GameObject> activeTiles;

        // Use this for initialization
        void Start() {
            activeTiles = new List<GameObject>();
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

            for (int i = 0; i < amountOfTilesOnScreen; i++)
            {
                if (i < 2)
                {
                    SpawnTile(0);
                }
                else
                {
                    SpawnTile();
                }
            }
        }

        // Update is called once per frame
        void Update() {
            if (playerTransform.position.z - safeZone > (spawnPointZ - amountOfTilesOnScreen * tileLength))
            {
                SpawnTile();
                DeleteTile();
            }
        }

        void SpawnTile(int gameObjectIndex = -1)
        {
            GameObject myGameObject;
            if (gameObjectIndex == -1)
            {
                myGameObject = Instantiate(tiles[RandomIndexGenerator()]) as GameObject;
            }
            else
            {
                myGameObject = Instantiate(tiles[gameObjectIndex]) as GameObject;
            }

            myGameObject.transform.SetParent(transform);
            myGameObject.transform.position = Vector3.forward * spawnPointZ;
            spawnPointZ += tileLength;
            activeTiles.Add(myGameObject);
        }

        void DeleteTile()
        {
            Destroy(activeTiles[0]);
            activeTiles.RemoveAt(0);
        }

        int RandomIndexGenerator()
        {
            if (tiles.Length <= 1)
            {
                return 0;
            }

            int randomIndex = lastGameObjectIndex;
            while (randomIndex == lastGameObjectIndex)
            {
                randomIndex = Random.Range(0, tiles.Length);
            }
            lastGameObjectIndex = randomIndex;
            return randomIndex;

        }
    }