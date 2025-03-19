using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShardManager : MonoBehaviour
{
    public int shardCount;
    public TMP_Text shardText;
    public GameObject door;
    private bool doorDestroyed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shardText.text = ": " + shardCount.ToString();
        
        if(shardCount == 10 && !doorDestroyed)
        {
            doorDestroyed = true;
            Destroy(door);
        }
    }
}
