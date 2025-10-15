using NodeCanvas.Framework;
using UnityEngine;
using UnityEngine.UI;

public class UtilityExample : MonoBehaviour
{
    public Blackboard blackboard;

    public Slider sleepySlider;
    public string sleepyVariableName;

    public Slider hungrySlider;
    public string hungryVariableName;

    public Slider eagerSlider;
    public string eagerVariableName;

    public Slider foodSlider;
    public string foodVariableName;

    public Slider woodSlider;
    public string woodVariableName;

    void Awake() {
        Bind(sleepySlider, sleepyVariableName);
        Bind(hungrySlider, hungryVariableName);
        Bind(eagerSlider, eagerVariableName);
        Bind(foodSlider, foodVariableName);
        Bind(woodSlider, woodVariableName);
    }

    void Bind(Slider slider, string variableName) {
        var variable = blackboard.GetVariable<float>(variableName);
        slider.value = (float)variable.value; //init
        variable.onValueChanged += (x) => slider.value = (float)x; //bind
    }
}
