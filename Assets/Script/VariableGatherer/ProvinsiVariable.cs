using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WawasanKebangsaanBase;

public class ProvinsiVariable : BaseVariableGatherer 
{
    [SerializeField]
    private Provinsi _Provinsi;

    public Provinsi GetProvinsi { get { return _Provinsi; } }
}
