using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace IND.DevTools.ErrorLogging
{
    [System.Serializable]
    public class IND_Error 
    {


        public ErrorType errorType;  
        [Multiline(5)]
        public string errorMessage;

    }

 

    public enum ErrorType
    {
        none,
        notice,
        warning,
        critical,

    }
}
