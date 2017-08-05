using UnityEngine;
using WawasanKebangsaanBase;
using System;
using System.Collections;
using System.Globalization;
using System.IO;

public class StaticFunction
{
    public static void WKMessageLog(string message)
    {
        Debug.Log("Wawasan Kebangsaan Log :: " + message);
    }
    public static void WKMessageWarning(string message)
    {
        Debug.LogWarning("Wawasan Kebangsaan LogWarning :: " + message);
    }
    public static void WKMessageError(string message)
    {
        Debug.LogError("Wawasan Kebangsaan LogError :: " + message);
    }

    public static string LambangURL(string name)
    {
        string url = "";
        if (Singleton.Instance.OnlineMode)
            url = CONTS_VAR.ONLINE_URL + CONTS_VAR.LAMBANG_PATH + name;
        else
            url = CONTS_VAR.OFFLINE_URL + CONTS_VAR.LAMBANG_PATH + name;

        return url;
    }
    public static string JSONURL(string name)
    {
        string url = "";
        if (Singleton.Instance.OnlineMode)
            url = CONTS_VAR.ONLINE_URL + CONTS_VAR.JSON_PATH + name + ".json";
        else
            url = CONTS_VAR.OFFLINE_URL + CONTS_VAR.JSON_PATH + name + ".json";

        return url;
    }
    public static string VideoURL(string name)
    {
        string url = "";
        if (Singleton.Instance.OnlineMode)
            url = CONTS_VAR.ONLINE_URL + CONTS_VAR.VIDEO_PATH + name;
        else
            url = CONTS_VAR.OFFLINE_URL + CONTS_VAR.VIDEO_PATH + name;

        return url;
    }

    public static int GetIDProvinsi(Provinsi prov)
    {
        int id = 0;
        switch (prov)
        {
            case Provinsi.JawaBarat:
                id = 1;
                break;
            case Provinsi.JawaTengah:
                id = 2;
                break;
            case Provinsi.NanggroeAcehDarussalam:
                id = 3;
                break;
            case Provinsi.Bali:
                id = 4;
                break;
            case Provinsi.Banten:
                id = 5;
                break;
            case Provinsi.Bengkulu:
                id = 6;
                break;
            case Provinsi.Gorontalo:
                id = 7;
                break;
            case Provinsi.DKIJakarta:
                id = 8;
                break;
            case Provinsi.Jambi:
                id = 9;
                break;
            case Provinsi.JawaTimur:
                id = 10;
                break;
            case Provinsi.KalimantanBarat:
                id = 11;
                break;
            case Provinsi.KalimantanSelatan:
                id = 12;
                break;
            case Provinsi.KalimantanTengah:
                id = 13;
                break;
            case Provinsi.KalimantanTimur:
                id = 14;
                break;
            case Provinsi.KalimantanUtara:
                id = 15;
                break;
            case Provinsi.DIYogyakarta:
                id = 16;
                break;
            case Provinsi.BangkaBelitung:
                id = 17;
                break;
            case Provinsi.KepulauanRiau:
                id = 18;
                break;
            case Provinsi.Lampung:
                id = 19;
                break;
            case Provinsi.Maluku:
                id = 20;
                break;
            case Provinsi.MalukuUtara:
                id = 21;
                break;
            case Provinsi.NusaTenggaraBarat:
                id = 22;
                break;
            case Provinsi.NusaTenggaraTimur:
                id = 23;
                break;
            case Provinsi.Papua:
                id = 24;
                break;
            case Provinsi.PapuaBarat:
                id = 25;
                break;
            case Provinsi.Riau:
                id = 26;
                break;
            case Provinsi.SulawesiBarat:
                id = 27;
                break;
            case Provinsi.SulawesiSelatan:
                id = 28;
                break;
            case Provinsi.SulawesiTengah:
                id = 29;
                break;
            case Provinsi.SulawesiUtara:
                id = 30;
                break;
            case Provinsi.SumateraBarat:
                id = 31;
                break;
            case Provinsi.SumateraSelatan:
                id = 32;
                break;
            case Provinsi.SumateraUtara:
                id = 33;
                break;
            case Provinsi.SulawesiTenggara:
                id = 34;
                break;
        }

        return id;
    }
    public static Provinsi GetEnumProvinsi(int id)
    {
        Provinsi prov = Provinsi.Null;
        switch (id)
        {
            case 1:
                prov = Provinsi.JawaBarat;
                break;
            case 2:
                prov = Provinsi.JawaTengah;
                break;
            case 3:
                prov = Provinsi.NanggroeAcehDarussalam;
                break;
            case 4:
                prov = Provinsi.Bali;
                break;
            case 5:
                prov = Provinsi.Banten;
                break;
            case 6:
                prov = Provinsi.Bengkulu;
                break;
            case 7:
                prov = Provinsi.Gorontalo;
                break;
            case 8:
                prov = Provinsi.DKIJakarta;
                break;
            case 9:
                prov = Provinsi.Jambi;
                break;
            case 10:
                prov = Provinsi.JawaTimur;
                break;
            case 11:
                prov = Provinsi.KalimantanBarat;
                break;
            case 12:
                prov = Provinsi.KalimantanSelatan;
                break;
            case 13:
                prov = Provinsi.KalimantanTengah;
                break;
            case 14:
                prov = Provinsi.KalimantanTimur;
                break;
            case 15:
                prov = Provinsi.KalimantanUtara;
                break;
            case 16:
                prov = Provinsi.DIYogyakarta;
                break;
            case 17:
                prov = Provinsi.BangkaBelitung;
                break;
            case 18:
                prov = Provinsi.KepulauanRiau;
                break;
            case 19:
                prov = Provinsi.Lampung;
                break;
            case 20:
                prov = Provinsi.Maluku;
                break;
            case 21:
                prov = Provinsi.MalukuUtara;
                break;
            case 22:
                prov = Provinsi.NusaTenggaraBarat;
                break;
            case 23:
                prov = Provinsi.NusaTenggaraTimur;
                break;
            case 24:
                prov = Provinsi.Papua;
                break;
            case 25:
                prov = Provinsi.PapuaBarat;
                break;
            case 26:
                prov = Provinsi.Riau;
                break;
            case 27:
                prov = Provinsi.SulawesiBarat;
                break;
            case 28:
                prov = Provinsi.SulawesiSelatan;
                break;
            case 29:
                prov = Provinsi.SulawesiTengah;
                break;
            case 30:
                prov = Provinsi.SulawesiUtara;
                break;
            case 31:
                prov = Provinsi.SumateraBarat;
                break;
            case 32:
                prov = Provinsi.SumateraSelatan;
                break;
            case 33:
                prov = Provinsi.SumateraUtara;
                break;
            case 34:
                prov = Provinsi.SulawesiTenggara;
                break;
        }

        return prov;
    }
    public static string GetNameProvinsi(int id)
    {
        return GetNameProvinsi(GetEnumProvinsi(id));
    }
    public static string GetNameProvinsi(Provinsi prov)
    {
        string name = "";
        switch (prov)
        {
            case Provinsi.JawaBarat:
                name = "Jawa Barat";
                break;
            case Provinsi.JawaTengah:
                name = "Jawa Tengah";
                break;
            case Provinsi.NanggroeAcehDarussalam:
                name = "Nanggroe Aceh Darussalam";
                break;
            case Provinsi.Bali:
                name = "Bali";
                break;
            case Provinsi.Banten:
                name = "Banten";
                break;
            case Provinsi.Bengkulu:
                name = "Bengkulu";
                break;
            case Provinsi.Gorontalo:
                name = "Gorontalo";
                break;
            case Provinsi.DKIJakarta:
                name = "DKI Jakarta";
                break;
            case Provinsi.Jambi:
                name = "Jambi";
                break;
            case Provinsi.JawaTimur:
                name = "Jawa Timur";
                break;
            case Provinsi.KalimantanBarat:
                name = "Kalimantan Barat";
                break;
            case Provinsi.KalimantanSelatan:
                name = "Kalimantan Selatan";
                break;
            case Provinsi.KalimantanTengah:
                name = "Kalimantan Tengah";
                break;
            case Provinsi.KalimantanTimur:
                name = "Kalimantan Timur";
                break;
            case Provinsi.KalimantanUtara:
                name = "Kalimantan Utara";
                break;
            case Provinsi.DIYogyakarta:
                name = "DI Yogyakarta";
                break;
            case Provinsi.BangkaBelitung:
                name = "Bangka Belitung";
                break;
            case Provinsi.KepulauanRiau:
                name = "Kepulauan Riau";
                break;
            case Provinsi.Lampung:
                name = "Lampung";
                break;
            case Provinsi.Maluku:
                name = "Maluku";
                break;
            case Provinsi.MalukuUtara:
                name = "Kepulauan Maluku";
                break;
            case Provinsi.NusaTenggaraBarat:
                name = "NusaTenggara Barat";
                break;
            case Provinsi.NusaTenggaraTimur:
                name = "NusaTenggara Timur";
                break;
            case Provinsi.Papua:
                name = "Papua";
                break;
            case Provinsi.PapuaBarat:
                name = "Papua Barat";
                break;
            case Provinsi.Riau:
                name = "Riau";
                break;
            case Provinsi.SulawesiBarat:
                name = "Sulawesi Barat";
                break;
            case Provinsi.SulawesiSelatan:
                name = "Sulawesi Selatan";
                break;
            case Provinsi.SulawesiTengah:
                name = "Sulawesi Tengah";
                break;
            case Provinsi.SulawesiUtara:
                name = "Sulawesi Utara";
                break;
            case Provinsi.SumateraBarat:
                name = "Sumatera Barat";
                break;
            case Provinsi.SumateraSelatan:
                name = "Sumatera Selatan";
                break;
            case Provinsi.SumateraUtara:
                name = "Sumatera Utara";
                break;
            case Provinsi.SulawesiTenggara:
                name = "Sulawesi Tenggara";
                break;
        }

        return name;
    }
    public static string GameObjectFullName(int id)
    {
        return id.ToString() + ": " + GetNameProvinsi(id);
    }
    public static string GameObjectFullName(Provinsi prov)
    {
        return GetIDProvinsi(prov).ToString() + ": " + GetNameProvinsi(prov);
    }
    public static GameObject Get3DProvinsi(int id)
    {
        return Get3DProvinsi(GetEnumProvinsi(id));
    }
    public static GameObject Get3DProvinsi(Provinsi prov)
    {
        GameObject go = null;
        switch (prov)
        {
            case Provinsi.JawaBarat:
                go = Singleton.Instance.Get3DProvinsi._JawaBarat;
                break;
            case Provinsi.JawaTengah:
                go = Singleton.Instance.Get3DProvinsi._JawaTengah;
                break;
            case Provinsi.NanggroeAcehDarussalam:
                go = Singleton.Instance.Get3DProvinsi._NanggroeAcehDarussalam;
                break;
            case Provinsi.Bali:
                go = Singleton.Instance.Get3DProvinsi._Bali;
                break;
            case Provinsi.Banten:
                go = Singleton.Instance.Get3DProvinsi._Banten;
                break;
            case Provinsi.Bengkulu:
                go = Singleton.Instance.Get3DProvinsi._Bengkulu;
                break;
            case Provinsi.Gorontalo:
                go = Singleton.Instance.Get3DProvinsi._Gorontalo;
                break;
            case Provinsi.DKIJakarta:
                go = Singleton.Instance.Get3DProvinsi._DKIJakarta;
                break;
            case Provinsi.Jambi:
                go = Singleton.Instance.Get3DProvinsi._Jambi;
                break;
            case Provinsi.JawaTimur:
                go = Singleton.Instance.Get3DProvinsi._JawaTimur;
                break;
            case Provinsi.KalimantanBarat:
                go = Singleton.Instance.Get3DProvinsi._KalimantanBarat;
                break;
            case Provinsi.KalimantanSelatan:
                go = Singleton.Instance.Get3DProvinsi._KalimantanSelatan;
                break;
            case Provinsi.KalimantanTengah:
                go = Singleton.Instance.Get3DProvinsi._KalimantanTengah;
                break;
            case Provinsi.KalimantanTimur:
                go = Singleton.Instance.Get3DProvinsi._KalimantanTimur;
                break;
            case Provinsi.KalimantanUtara:
                go = Singleton.Instance.Get3DProvinsi._KalimantanUtara;
                break;
            case Provinsi.DIYogyakarta:
                go = Singleton.Instance.Get3DProvinsi._DIYogyakarta;
                break;
            case Provinsi.BangkaBelitung:
                go = Singleton.Instance.Get3DProvinsi._BangkaBelitung;
                break;
            case Provinsi.KepulauanRiau:
                go = Singleton.Instance.Get3DProvinsi._KepulauanRiau;
                break;
            case Provinsi.Lampung:
                go = Singleton.Instance.Get3DProvinsi._Lampung;
                break;
            case Provinsi.Maluku:
                go = Singleton.Instance.Get3DProvinsi._Maluku;
                break;
            case Provinsi.MalukuUtara:
                go = Singleton.Instance.Get3DProvinsi._MalukuUtara;
                break;
            case Provinsi.NusaTenggaraBarat:
                go = Singleton.Instance.Get3DProvinsi._NusaTenggaraBarat;
                break;
            case Provinsi.NusaTenggaraTimur:
                go = Singleton.Instance.Get3DProvinsi._NusaTenggaraTimur;
                break;
            case Provinsi.Papua:
                go = Singleton.Instance.Get3DProvinsi._Papua;
                break;
            case Provinsi.PapuaBarat:
                go = Singleton.Instance.Get3DProvinsi._PapuaBarat;
                break;
            case Provinsi.Riau:
                go = Singleton.Instance.Get3DProvinsi._Riau;
                break;
            case Provinsi.SulawesiBarat:
                go = Singleton.Instance.Get3DProvinsi._SulawesiBarat;
                break;
            case Provinsi.SulawesiSelatan:
                go = Singleton.Instance.Get3DProvinsi._SulawesiSelatan;
                break;
            case Provinsi.SulawesiTengah:
                go = Singleton.Instance.Get3DProvinsi._SulawesiTengah;
                break;
            case Provinsi.SulawesiUtara:
                go = Singleton.Instance.Get3DProvinsi._SulawesiUtara;
                break;
            case Provinsi.SumateraBarat:
                go = Singleton.Instance.Get3DProvinsi._SumateraBarat;
                break;
            case Provinsi.SumateraSelatan:
                go = Singleton.Instance.Get3DProvinsi._SumateraSelatan;
                break;
            case Provinsi.SumateraUtara:
                go = Singleton.Instance.Get3DProvinsi._SumateraUtara;
                break;
            case Provinsi.SulawesiTenggara:
                go = Singleton.Instance.Get3DProvinsi._SulawesiTenggara;
                break;
        }
        return go;
    }

    public static string URLAssetBundle(EAssetsBundle bundle)
    {
        string url = CONTS_VAR.ONLINE_URL + CONTS_VAR.ASSETBUNDLE_PATH;

        switch (bundle)
        {
            case EAssetsBundle.AssetsBundle3D:
                url += "3d";
                break;
        }

        return url;
    }

    public static string Path3DFormAssetBundle(E3DType name3D)
    {
        string path = "";

        switch (name3D)
        {
            case E3DType.BARONG:
                path = "Assets/3D/barong bali/barong.fbx";
                break;
        }

        return path;
    }

}