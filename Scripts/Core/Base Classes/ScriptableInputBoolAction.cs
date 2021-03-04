
using UnityEngine;
using Sirenix.OdinInspector;

namespace IND.Core
{
    [CreateAssetMenu(fileName = "Input Bool Action", menuName = "IND/Variables/Inputs/Input Bool Action")]
    public class ScriptableInputBoolAction : ScriptableObject
    {
        [InlineEditor] public ScriptableBool value;
    }
}