using UnityEngine;

public class Rule_Arrows : MonoBehaviour
{
    
    public bool RuleCorrect = false;
    [SerializeField]
    private LayerMask puzzleOrb;
    [SerializeField]
    private RuleCheckerGeneral RuleCheckerGeneral;

    [Header ("Direction objects")]
    [SerializeField]
    private Transform NorthOrigin;
    [SerializeField]
    private int NorthOrbs;
    public float NorthDetectionLength;
    private int NorthHitCount;

    [SerializeField]
    private Transform EastOrigin;
    [SerializeField]
    private int EastOrbs;
    public float EastDetectionLength;
    private int EastHitCount;

    [SerializeField]
    private Transform SouthOrigin;
    [SerializeField] 
    private int SouthOrbs;
    public float SouthDetectionLength;
    private int SouthHitCount;

    [SerializeField]
    private Transform WestOrigin;
    [SerializeField]
    private int WestOrbs;
    public float WestDetectionLength;
    private int WestHitCount;

    //At the moment the direction is called in world space. meaning that the puzzle can't be rotated without this code breaking.
    //TODO, make north of puzzle, norht of raycast. for all directions too.
    void Update()
    {
        //Debug.DrawRay(NorthOrigin.position, Vector3.forward * NorthDetectionLength, Color.red);
        //Debug.DrawRay(EastOrigin.position, Vector3.right * EastDetectionLength, Color.green);
        //Debug.DrawRay(SouthOrigin.position, Vector3.back * SouthDetectionLength, Color.blue);
        //Debug.DrawRay(WestOrigin.position, Vector3.left * WestDetectionLength, Color.yellow);
        
}
    //launch each of the 4 checks.
    public void PressedCheck()
    {
        if (NorthOrbs != 0)
        {
            RaycastNorth();
        }
        if (EastOrbs != 0)
        {
            RaycastEast();
        }
        if (SouthOrbs != 0)
        {
            RaycastSouth();
        }
        if (WestOrbs != 0)
        {
            RaycastWest();
        }


        //RaycastNorth();
        //RaycastEast();
        //RaycastSouth();
        //RaycastWest();

        //check if all 4 are correct and pass that information off to the 'puzzleChecker'
        if (NorthOrbs == NorthHitCount & EastOrbs == EastHitCount & SouthOrbs == SouthHitCount & WestOrbs == WestHitCount)
        {
            RuleCorrect = true;
            RuleCheckerGeneral.puzzleIsCorrect = true;
        }
        else
        {
            RuleCorrect= false;
            RuleCheckerGeneral.puzzleIsCorrect = false;
        }

        //Debug.Log("Norht = " + NorthHitCount);
        //Debug.Log("East = " + EastHitCount);
        //Debug.Log("South = " + SouthHitCount);
        //Debug.Log("West = " + WestHitCount);
        //Debug.Log(RuleCorrect);

    }
    #region Direction Checks
    public void RaycastNorth()
    {
        
        if (NorthOrigin == null) return;

        RaycastHit[] NorthHit = Physics.RaycastAll(NorthOrigin.position, Vector3.forward, NorthDetectionLength, puzzleOrb);

        NorthHitCount = NorthHit.Length;
       
    }

    public void RaycastEast()
    {
        
        if (EastOrigin == null) return;

        RaycastHit[] EastHit = Physics.RaycastAll(EastOrigin.position, Vector3.right, EastDetectionLength, puzzleOrb);

        EastHitCount = EastHit.Length;
        
    }

    public void RaycastSouth()
    {
        
        if (SouthOrigin == null) return;

        RaycastHit[] SouthHit = Physics.RaycastAll(SouthOrigin.position, Vector3.back, SouthDetectionLength, puzzleOrb);

        SouthHitCount = SouthHit.Length;

    }

    public void RaycastWest()
    {
       
        if (WestOrigin == null) return;

        RaycastHit[] WestHit = Physics.RaycastAll(WestOrigin.position, Vector3.left, WestDetectionLength, puzzleOrb);

        WestHitCount = WestHit.Length;

    }

    #endregion
}
