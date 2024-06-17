using UnityEngine;

public class PlayerStat : MonoBehaviour 
{ 
    public float curValue;
    public float startValue;
    private void Start()
    {
        curValue = startValue;
    }

    public void Subtract(float value)
    {
        curValue = Mathf.Max(curValue - value,0);
    }
}