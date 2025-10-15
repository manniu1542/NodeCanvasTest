using UnityEngine;
using NodeCanvas.Framework;
using UnityEngine.UI;

//Example script on how to use the onValueChange event of blackboard variables
public class ScoreUpdater : MonoBehaviour
{
    public Blackboard blackboard;
    public string variableName;
    public Text text;

    //Subscribe and update text once
    void Start() {
        var variable = blackboard.GetVariable(variableName);
        if ( variable != null ) {
            variable.onValueChanged += VariableValueChanged;
            VariableValueChanged(variable.value);
        }
    }

    //Called when variable value changed. Update text
    void VariableValueChanged(object newValue) {
        text.text = $"HitPoints: {newValue?.ToString()}";
    }
}
