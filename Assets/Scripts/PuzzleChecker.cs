using System.Collections.Generic;
using UnityEngine;

public class PuzzleChecker : MonoBehaviour
{
    [SerializeField]
    private Dictionary<GameObject, bool> ruleCorrectDict = new Dictionary<GameObject, bool>()
    {
        {new GameObject(), false},
        {new GameObject(), false},
        {new GameObject(), false},
        {new GameObject(), false},
        {new GameObject(), false}
    };

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
