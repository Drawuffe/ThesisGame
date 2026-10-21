using UnityEngine;

public class BurrowSpawning : MonoBehaviour
{
    public ScriptableObject cornerSO, straightSO, threeSO, fourSO;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cornerSO = GameObject.FindWithTag("Corner").GetComponent<ScriptableObject>();
        straightSO = GameObject.FindWithTag("Straight").GetComponent<ScriptableObject>();
        threeSO = GameObject.FindWithTag("Three").GetComponent<ScriptableObject>();
        fourSO = GameObject.FindWithTag("Four").GetComponent<ScriptableObject>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CornerSpawn()
    {
        
    }

    public void StraightSpawn()
    {
        
    }

    public void ThreeSpawn()
    {
        
    }

    public void FourSpawn()
    {
        
    }
}
