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
    [SerializeField] private GameObject CompleteButton;
    
   
    public void CheckTheRules()
    {
        // set the base that the puzzle is correct. only gets set to incorrect if a rule is incorrect.
        AllCorrect = true;
        //go through each rule and check if they are correct.
        foreach (GameObject obj in RulesToCheck)
        {
            //get the scripts in the event of 'RuleCheckerGeneral'. 
            RuleCheckerGeneral script = obj.GetComponent<RuleCheckerGeneral>();
            //check if the rules are correct by calling the event.
            script.CallFunction();
            if (script == null)
            {
                //only fires if there is no script to the object in the array
                Debug.Log("you're missing a script dude");
                continue;
            }

            if (script.puzzleIsCorrect == false)
            {
                //only fires if the rule is incorrect. to this you can add code for specific rules, like what happens to the colour to that specific rule.
                AllCorrect = false;
                Debug.Log("this rule is incorrect");
            }
        }

        //TODO. when a puzzle piece is moved, set the state of the puzzle to base (aka colour changé in the current version)

        if (AllCorrect)
        {
            //puzzle is correct. add code here for what happens next. 
            //TODO. Event system which can add specific reactions in the world like opening a gate.
            Debug.Log("you did it, woohoo");
            Floor.GetComponent<Renderer>().material = materialCorrect;
            CompleteButton.SetActive(true);
            
        }
        else
        {
            //puzzle is incorrect. add code for incorrectness.
            Debug.Log("Haha, you suck. byeeee");
            Floor.GetComponent<Renderer>().material = materialIncorrect;
            CompleteButton.SetActive(false);
        }
    }
}
