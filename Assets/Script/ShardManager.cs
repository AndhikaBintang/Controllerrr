using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShardManager : MonoBehaviour
{
    public TMP_Text shardText;
    public TMP_Text gameOverPoints;
    public GameObject door;
    private bool doorDestroyed;


 
    public int shardCount;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shardText.text = ": " + shardCount.ToString();
        gameOverPoints.text = "Points : " + shardCount.ToString();
        if(shardCount == 10 && !doorDestroyed)
        {
            doorDestroyed = true;
            Destroy(door);
        }
    }
}
