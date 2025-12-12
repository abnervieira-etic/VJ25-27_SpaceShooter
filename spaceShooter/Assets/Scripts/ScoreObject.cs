using UnityEngine;

public class ScoreObject : MonoBehaviour
{
    [SerializeField] private int score;

    void OnDestroy()
    {
        GameObject.Find("UImanager").GetComponent<UIManager>().AddScore(score);        
    }
}
