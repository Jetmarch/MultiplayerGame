using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWorldGenerator : MonoBehaviour
{

    [SerializeField]
    private GameObject blockPref;

    [SerializeField]
    private float worldHieght;

    [SerializeField]
    private float worldWidth;

    [SerializeField]
    private Vector2 firstBlockSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        for(int x = 0; x < worldWidth; x++)
        {
            for(int y = 0; y < worldHieght; y++)
            {
                Instantiate(blockPref, new Vector2(x + 0.1f, -y + 0.1f) + firstBlockSpawnPoint, blockPref.transform.rotation);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
