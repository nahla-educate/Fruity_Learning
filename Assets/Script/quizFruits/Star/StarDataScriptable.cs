using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "StarData", menuName = "StarData")]
public class StarDataScriptable : ScriptableObject
{
    public List<QuestionStar> questions;
}
