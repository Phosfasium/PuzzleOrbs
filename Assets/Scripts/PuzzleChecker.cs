using System.Collections.Generic;
using UnityEngine;

public class PuzzleChecker : MonoBehaviour
{
    public List<GameObject> RulesToCheck;
    private bool AllCorrect;

    [SerializeField] private Material materialStandard;
    [SerializeField] private Material materialCorrect;
    [SerializeField] private Material materialIncorrect;
    [SerializeField] private GameObject Floor;
    
    public void CheckTheRules()
    {
        AllCorrect = true;
        foreach (GameObject obj in RulesToCheck)
        {
            RuleCheckerGeneral script = obj.GetComponent<RuleCheckerGeneral>();

            if (script == null)
            {
                Debug.Log("you're missing a script dude");
                continue;
            }

            if (script.puzzleIsCorrect == false)
            {
                AllCorrect = false;
                Debug.Log("this rule is incorrect");
            }
        }

        if (AllCorrect)
        {
            Debug.Log("you did it, woohoo");
            Floor.GetComponent<Renderer>().material = materialCorrect;
            
        }
        else
        {
            Debug.Log("Haha, you suck. byeeee");
            Floor.GetComponent<Renderer>().material = materialIncorrect;
        }
    }
}
