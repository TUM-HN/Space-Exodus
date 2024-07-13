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
        snapTurn.rightHandSnapTurnAction.action.Enable();
        continuousTurn.rightHandTurnAction.action.Disable();

        continuousTurn.leftHandTurnAction.action.Disable();
        snapTurn.leftHandSnapTurnAction.action.Enable();

    }

    private void ContinuousTurnEnable() {
        snapTurn.rightHandSnapTurnAction.action.Disable();
        continuousTurn.leftHandTurnAction.action.Enable();
        snapTurn.leftHandSnapTurnAction.action.Disable();

        continuousTurn.rightHandTurnAction.action.Enable();
    }
}
