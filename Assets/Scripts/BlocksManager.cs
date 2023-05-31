using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksManager : MonoBehaviour
{
    World world;
    float blockWidth;
    float blocksPerRow=5f;

    private void Awake() {
        world = GetComponentInParent<World>();
    }

    void CalculateBlockWidth() {
        Debug.Log(world.innerBounds);
        blockWidth = (float) world.innerBounds / blocksPerRow;
        Debug.Log(blockWidth);
    }

    // Start is called before the first frame update
    void Start()
    {
        CalculateBlockWidth();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
