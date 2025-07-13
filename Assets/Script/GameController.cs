using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject coin;
    public GameObject tree;
    public float countTime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int num = Random.Range(1, 3);
        countTime -= Time.deltaTime;
        if (num<=1)
        {
            
            if (countTime <= 0)
            {
                Instantiate(coin, new Vector3(9.5f, -1f, 0), new Quaternion());
                countTime = Random.Range(1, 5);
            }
        } else if(num>=2)
        {
            
            if (countTime <= 0)
            {
    
                Instantiate(tree, new Vector3(9.5f, -1, 0), new Quaternion());
                countTime = Random.Range(1, 5);
            }
        }

        
    }
}
