using System.Collections.Generic;
using UnityEngine;


public class PuzzleChecker : MonoBehaviour
{
    //public List<GameObject> RulesToCheck;
    private bool AllCorrect;
    [Header ("Puzzle elements")]
    public GameObject BoxesParent;
    public GameObject OrbParent;
    [SerializeField]
    private List<GameObject> BoxesToCheck;
    [SerializeField]
    private int OrbAmountToCheck;
    private int orbAmount;
    private bool AllOrbs;
    [Header ("Puzzle complete items")]
    [SerializeField] private Material materialStandard;
    [SerializeField] private Material materialCorrect;
    [SerializeField] private Material materialIncorrect;
    [SerializeField] private GameObject Floor;
    [SerializeField] private GameObject CompleteButton;

    private void Start()
    {
        foreach (Transform child in BoxesParent.transform)
        {
            BoxesToCheck.Add(child.gameObject);
        }

        OrbAmountToCheck = OrbParent.transform.childCount;

    }
    public void CheckTheRules()
    {
        // set the base that the puzzle is correct. only gets set to incorrect if a rule is incorrect.
        AllCorrect = true;
        orbAmount = 0;
        AllOrbs = false;





        foreach (GameObject child in BoxesToCheck)
        {
            //Check each box if they have an orb
            OrbChecker orbScript = child.GetComponent<OrbChecker>();
            
            if (orbScript == null)
            {
                //Debug.Log("Another script bites the dust");
                continue;
            }

            if (orbScript != null)
            {
                orbScript.hasOrb = false;
                orbScript.CallFunction();
                if (orbScript.hasOrb == true)
                {
                    orbAmount = orbAmount + 1;
                }
            }

        }


        foreach (GameObject child in BoxesToCheck)
        {
            //Check each rule if it is correct
            //get the scripts in the event of 'RuleCheckerGeneral'. 
            RuleCheckerGeneral RuleScript = child.GetComponent<RuleCheckerGeneral>();
            //check if the rules are correct by calling the event.
            if (RuleScript == null)
            {
                //only fires if there is no script to the object in the array
                //Debug.Log("you're missing a script dude");
                continue;
            }

            if (RuleScript != null)
            {
                RuleScript.CallFunction();

                if (RuleScript.puzzleIsCorrect == false)
                {
                    //only fires if the rule is incorrect. to this you can add code for specific rules, like what happens to the colour to that specific rule.
                    AllCorrect = false;
                    Debug.Log("this rule is incorrect");
                }
            }
        }


        Debug.Log(orbAmount);
        if (orbAmount == OrbAmountToCheck)
        {
            AllOrbs = true;
        }



        //TODO. when a puzzle piece is moved, set the state of the puzzle to base (aka colour changé in the current version)

        if (AllCorrect && AllOrbs)
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
