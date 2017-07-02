using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoVariable : BaseVariableGatherer 
{
    [SerializeField]
    private Text _VideoName;

    public Text GetVideoName { get { return _VideoName; } }
}
