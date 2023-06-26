using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PearData", menuName = "PearData")]
public class PearDataScriptable : ScriptableObject
{
    public List<QuestionPear> questions;
}
