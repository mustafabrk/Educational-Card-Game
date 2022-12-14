using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kart : MonoBehaviour
{
    public GameObject[] Kartlar;
    public Transform Kamera;
    public Transform Masa;

    public GameObject dogruIkon;
    public GameObject yanlisIkon;

    public int baslangicKartNumarasi;
    public int yanlisKartNumarasi1;
    public int yanlisKartNumarasi2;

    public int masadakiKartNumarasi;
    public int dogruKartNumarasi;

    public int basladiMi = 0;
    public int dizininElemanSayisi = 0;

    public int kartSayaci = 1;

    void Awake()
    {
        dogruIkon.SetActive(false);
        yanlisIkon.SetActive(false);

        baslangicKartNumarasi = Random.Range(0, 39);
        Debug.Log(baslangicKartNumarasi);
        Kartlar[baslangicKartNumarasi].transform.position = new Vector3(-3, 0.1f, 0);
        Kartlar[baslangicKartNumarasi].SetActive(true);
        Kartlar[baslangicKartNumarasi].gameObject.tag = "AcilmisKartlar";

        Kartlar[baslangicKartNumarasi + 1].transform.position = new Vector3(5f, 1, -2.25f);
        Kartlar[baslangicKartNumarasi + 1].SetActive(true);
        Kartlar[baslangicKartNumarasi + 1].gameObject.tag = "AcilmisKartlar";

        yanlisKartNumarasi1 = Random.Range(0, 40);
        yanlisKartNumarasi1 = KartlariKontrolEt(yanlisKartNumarasi1);
        Debug.Log(yanlisKartNumarasi1);
        Kartlar[yanlisKartNumarasi1].transform.position = new Vector3(5, 1, 0);
        Kartlar[yanlisKartNumarasi1].SetActive(true);
        Kartlar[yanlisKartNumarasi1].gameObject.tag = "AcilmisKartlar";

        yanlisKartNumarasi2 = Random.Range(0, 40);
        yanlisKartNumarasi2 = KartlariKontrolEt(yanlisKartNumarasi2);
        Debug.Log(yanlisKartNumarasi2);
        Kartlar[yanlisKartNumarasi2].transform.position = new Vector3(5, 1, 2.25f);
        Kartlar[yanlisKartNumarasi2].SetActive(true);
        Kartlar[yanlisKartNumarasi2].gameObject.tag = "AcilmisKartlar";
    }

    private int KartlariKontrolEt(int rastgeleSayi)
    {
        for(int i = 0; i < Kartlar.Length; i++)
        {
            if(Kartlar[rastgeleSayi].gameObject.tag == Kartlar[i].gameObject.tag && Kartlar[i].gameObject.tag == "AcilmisKartlar")
            {
                Debug.Log("Bidaha salla");
                rastgeleSayi = Random.Range(0, 40);
                i = 0;
            }
        }

        return rastgeleSayi;
    }
}
