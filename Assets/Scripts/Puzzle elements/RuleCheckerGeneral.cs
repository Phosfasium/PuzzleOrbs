using UnityEngine;
using UnityEngine.Events;

public class RuleCheckerGeneral : MonoBehaviour
{
    //Add this to any puzzle with a rule and add the rule to the event. the check looks for all the rules attached to this script and checks if they are correct.
    public bool puzzleIsCorrect;
    [SerializeField] private UnityEvent RuleToCheck;

    //call all the rules in the event 'rules to check' and pass it through to the puzzle checker
    public void CallFunction()
    {
        RuleToCheck.Invoke();
    }

}
