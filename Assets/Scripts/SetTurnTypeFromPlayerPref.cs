using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SetTurnTypeFromPlayerPref : MonoBehaviour
{
    public ActionBasedSnapTurnProvider snapTurn;
    public ActionBasedContinuousTurnProvider continuousTurn;

    // Start is called before the first frame update
    void Start()
    {
        ApplyPlayerPref();
    }

    public void ApplyPlayerPref()
    {
        if (PlayerPrefs.HasKey("turn"))
        {
            int value = PlayerPrefs.GetInt("turn");
            if (value == 0) SnapTurnEnable();
            else if (value == 1) ContinuousTurnEnable();
        }
        else SnapTurnEnable();

    }

    private void SnapTurnEnable() {
        snapTurn.leftHandSnapTurnAction.action.Enable();
        snapTurn.rightHandSnapTurnAction.action.Enable();
        continuousTurn.leftHandTurnAction.action.Disable();
        continuousTurn.rightHandTurnAction.action.Disable();
    }

    private void ContinuousTurnEnable() {
        snapTurn.leftHandSnapTurnAction.action.Disable();
        snapTurn.rightHandSnapTurnAction.action.Disable();
        continuousTurn.leftHandTurnAction.action.Enable();
        continuousTurn.rightHandTurnAction.action.Enable();
    }
}
