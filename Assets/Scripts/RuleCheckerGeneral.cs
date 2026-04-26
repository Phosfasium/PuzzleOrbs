using UnityEngine;
using UnityEngine.Events;

public class RuleCheckerGeneral : MonoBehaviour
{
    public bool puzzleIsCorrect;
    [SerializeField] private UnityEvent RuleToCheck;

    public void CallFunction()
    {
        RuleToCheck.Invoke();
    }

}
