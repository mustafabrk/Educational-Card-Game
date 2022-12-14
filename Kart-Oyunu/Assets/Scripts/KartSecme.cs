using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KartSecme : MonoBehaviour
{
    public GameObject sinifCagir;
    public GameObject[] Kartlar;

    private void Start()
    {
        Kartlar = sinifCagir.GetComponent<Kart>().Kartlar;
    }

    private void OnMouseDown()
    {
        if (sinifCagir.GetComponent<Kart>().basladiMi == 0)
        {
            sinifCagir.GetComponent<Kart>().masadakiKartNumarasi = sinifCagir.GetComponent<Kart>().baslangicKartNumarasi;
            sinifCagir.GetComponent<Kart>().dogruKartNumarasi = sinifCagir.GetComponent<Kart>().baslangicKartNumarasi + 1;

            KartKontrol();

            this.gameObject.transform.position = new Vector3(
                Kartlar[sinifCagir.GetComponent<Kart>().baslangicKartNumarasi].transform.position.x - 1.5f,
                Kartlar[sinifCagir.GetComponent<Kart>().baslangicKartNumarasi].transform.position.y + 0.01f,
                Kartlar[sinifCagir.GetComponent<Kart>().baslangicKartNumarasi].transform.position.z);

            sinifCagir.GetComponent<Kart>().basladiMi = 1;
        }
        else if(sinifCagir.GetComponent<Kart>().basladiMi == 1)
        {
            KartKontrol();
        }
        else
        {
            this.gameObject.transform.position = new Vector3(
                Kartlar[sinifCagir.GetComponent<Kart>().masadakiKartNumarasi].transform.position.x - 1.5f,
                Kartlar[sinifCagir.GetComponent<Kart>().masadakiKartNumarasi].transform.position.y + 0.01f,
                Kartlar[sinifCagir.GetComponent<Kart>().masadakiKartNumarasi].transform.position.z);

            sinifCagir.GetComponent<Kart>().masadakiKartNumarasi = Array.IndexOf(Kartlar, this.gameObject);

            this.gameObject.SetActive(true);

            sinifCagir.GetComponent<Kart>().kartSayaci++;
        }


        if(sinifCagir.GetComponent<Kart>().kartSayaci <= 37)
            KartAc();

        if (sinifCagir.GetComponent<Kart>().kartSayaci > 37 && sinifCagir.GetComponent<Kart>().kartSayaci < 40)
        {
            KalanKartlariAc();
            sinifCagir.GetComponent<Kart>().basladiMi = 2;
        }

        if (sinifCagir.GetComponent<Kart>().kartSayaci == 40)
        {
            StartCoroutine(DogruIkon(2.5f));
            StartCoroutine(BastanBasla(1f));
        }
    }

    private void KartKontrol()
    {
        if (this.name == Kartlar[sinifCagir.GetComponent<Kart>().dogruKartNumarasi].name)
        {
            Debug.Log("Doðru");

            Kartlar[sinifCagir.GetComponent<Kart>().yanlisKartNumarasi1].SetActive(false);
            Kartlar[sinifCagir.GetComponent<Kart>().yanlisKartNumarasi2].SetActive(false);
            this.gameObject.tag = "AcilmisKartlar";
        }
        else if (this.name == Kartlar[sinifCagir.GetComponent<Kart>().yanlisKartNumarasi1].name)
        {
            Debug.Log("Yanlýþ");

            Kartlar[sinifCagir.GetComponent<Kart>().dogruKartNumarasi].SetActive(false);
            Kartlar[sinifCagir.GetComponent<Kart>().dogruKartNumarasi].gameObject.tag = "AcilmamisKartlar";
            Kartlar[sinifCagir.GetComponent<Kart>().yanlisKartNumarasi2].SetActive(false);
            this.gameObject.tag = "AcilmisKartlar";

            StartCoroutine(YanlisIkon(2.5f));
            StartCoroutine(BastanBasla(1f));
        }
        else if (this.name == Kartlar[sinifCagir.GetComponent<Kart>().yanlisKartNumarasi2].name)
        {
            Debug.Log("Yanlýþ");

            Kartlar[sinifCagir.GetComponent<Kart>().dogruKartNumarasi].SetActive(false);
            Kartlar[sinifCagir.GetComponent<Kart>().dogruKartNumarasi].gameObject.tag = "AcilmamisKartlar";
            Kartlar[sinifCagir.GetComponent<Kart>().yanlisKartNumarasi1].SetActive(false);
            this.gameObject.tag = "AcilmisKartlar";

            StartCoroutine(YanlisIkon(2.5f));
            StartCoroutine(BastanBasla(1f));
        }

        this.gameObject.transform.position = new Vector3(
            Kartlar[sinifCagir.GetComponent<Kart>().masadakiKartNumarasi].transform.position.x - 1.5f,
            Kartlar[sinifCagir.GetComponent<Kart>().masadakiKartNumarasi].transform.position.y + 0.01f,
            Kartlar[sinifCagir.GetComponent<Kart>().masadakiKartNumarasi].transform.position.z);

        sinifCagir.GetComponent<Kart>().masadakiKartNumarasi = Array.IndexOf(Kartlar, this.gameObject);

        this.gameObject.SetActive(true);

        sinifCagir.GetComponent<Kart>().kartSayaci++;
    }

    private void KartAc()
    {
        int kartSirasi = UnityEngine.Random.Range(0, 100);
        sinifCagir.GetComponent<Kart>().dogruKartNumarasi = DogruKartNumarasi();
        Kartlar[sinifCagir.GetComponent<Kart>().dogruKartNumarasi].gameObject.tag = "DogruKart"; 
        sinifCagir.GetComponent<Kart>().yanlisKartNumarasi1 = RastgeleKartNumarasiSec();
        sinifCagir.GetComponent<Kart>().yanlisKartNumarasi1 = KartlariKontrolEt(sinifCagir.GetComponent<Kart>().yanlisKartNumarasi1);
        sinifCagir.GetComponent<Kart>().yanlisKartNumarasi2 = RastgeleKartNumarasiSec();
        sinifCagir.GetComponent<Kart>().yanlisKartNumarasi2 = KartlariKontrolEt(sinifCagir.GetComponent<Kart>().yanlisKartNumarasi2);

        if (kartSirasi <= 33)
        {
            Kartlar[sinifCagir.GetComponent<Kart>().dogruKartNumarasi].transform.position = new Vector3(sinifCagir.GetComponent<Kart>().Masa.position.x - 2.75f, 1, -2.25f);
            Kartlar[sinifCagir.GetComponent<Kart>().dogruKartNumarasi].SetActive(true);

            Kartlar[sinifCagir.GetComponent<Kart>().yanlisKartNumarasi1].transform.position = new Vector3(sinifCagir.GetComponent<Kart>().Masa.position.x - 2.75f, 1, 0);
            Kartlar[sinifCagir.GetComponent<Kart>().yanlisKartNumarasi1].SetActive(true);

            Kartlar[sinifCagir.GetComponent<Kart>().yanlisKartNumarasi2].transform.position = new Vector3(sinifCagir.GetComponent<Kart>().Masa.position.x - 2.75f, 1, 2.25f);
            Kartlar[sinifCagir.GetComponent<Kart>().yanlisKartNumarasi2].SetActive(true);
        }
        else if (kartSirasi > 33 && kartSirasi <= 66)
        {
            Kartlar[sinifCagir.GetComponent<Kart>().dogruKartNumarasi].transform.position = new Vector3(sinifCagir.GetComponent<Kart>().Masa.position.x - 2.75f, 1, 0);
            Kartlar[sinifCagir.GetComponent<Kart>().dogruKartNumarasi].SetActive(true);

            Kartlar[sinifCagir.GetComponent<Kart>().yanlisKartNumarasi1].transform.position = new Vector3(sinifCagir.GetComponent<Kart>().Masa.position.x - 2.75f, 1, -2.25f);
            Kartlar[sinifCagir.GetComponent<Kart>().yanlisKartNumarasi1].SetActive(true);

            Kartlar[sinifCagir.GetComponent<Kart>().yanlisKartNumarasi2].transform.position = new Vector3(sinifCagir.GetComponent<Kart>().Masa.position.x - 2.75f, 1, 2.25f);
            Kartlar[sinifCagir.GetComponent<Kart>().yanlisKartNumarasi2].SetActive(true);
        }
        else if (kartSirasi > 66 && kartSirasi <= 100)
        {
            Kartlar[sinifCagir.GetComponent<Kart>().dogruKartNumarasi].transform.position = new Vector3(sinifCagir.GetComponent<Kart>().Masa.position.x - 2.75f, 1, 2.25f);
            Kartlar[sinifCagir.GetComponent<Kart>().dogruKartNumarasi].SetActive(true);

            Kartlar[sinifCagir.GetComponent<Kart>().yanlisKartNumarasi1].transform.position = new Vector3(sinifCagir.GetComponent<Kart>().Masa.position.x - 2.75f, 1, -2.25f);
            Kartlar[sinifCagir.GetComponent<Kart>().yanlisKartNumarasi1].SetActive(true);

            Kartlar[sinifCagir.GetComponent<Kart>().yanlisKartNumarasi2].transform.position = new Vector3(sinifCagir.GetComponent<Kart>().Masa.position.x - 2.75f, 1, 0);
            Kartlar[sinifCagir.GetComponent<Kart>().yanlisKartNumarasi2].SetActive(true);
        }

        sinifCagir.GetComponent<Kart>().Kamera.position = new Vector3(this.gameObject.transform.position.x + 3,
                                                                    sinifCagir.GetComponent<Kart>().Kamera.position.y,
                                                                    sinifCagir.GetComponent<Kart>().Kamera.position.z);

        sinifCagir.GetComponent<Kart>().Masa.position = new Vector3(sinifCagir.GetComponent<Kart>().Masa.position.x - 1.5f,
                                                                    sinifCagir.GetComponent<Kart>().Masa.position.y,
                                                                    sinifCagir.GetComponent<Kart>().Masa.position.z);
    }

    private int DogruKartNumarasi()
    {
        sinifCagir.GetComponent<Kart>().dogruKartNumarasi = sinifCagir.GetComponent<Kart>().masadakiKartNumarasi + 1;

        if (sinifCagir.GetComponent<Kart>().masadakiKartNumarasi == 39)
            sinifCagir.GetComponent<Kart>().dogruKartNumarasi = 0;

        return sinifCagir.GetComponent<Kart>().dogruKartNumarasi;
    }

    private int KartlariKontrolEt(int rastgeleSayi)
    {
        for (int i = 0; i < Kartlar.Length; i++)
        {
            if ((Kartlar[rastgeleSayi].gameObject.tag == Kartlar[i].gameObject.tag && Kartlar[i].gameObject.tag == "AcilmisKartlar") || 
                (Kartlar[rastgeleSayi].gameObject.tag == Kartlar[i].gameObject.tag && Kartlar[i].gameObject.tag == "DogruKart"))
            {
                Debug.Log("Bidaha salla");
                rastgeleSayi = UnityEngine.Random.Range(0, 40);
                i = 0;
            }
        }
        return rastgeleSayi;
    }

    private void KalanKartlariAc()
    {
        int donguSayaci = 0;

        for (int i = 0; i < Kartlar.Length; i++)
        {
            if (Kartlar[i].gameObject.tag == "AcilmamisKartlar")
            {
                if(donguSayaci == 0)
                {
                    Kartlar[i].transform.position = new Vector3(sinifCagir.GetComponent<Kart>().Masa.position.x - 1.25f, 1, -1.5f);
                    Kartlar[i].gameObject.tag = "DogruKart";
                }

                else if (donguSayaci >= 1)
                {
                    Kartlar[i].transform.position = new Vector3(sinifCagir.GetComponent<Kart>().Masa.position.x - 1.25f, 1, 1.5f);
                    Kartlar[i].gameObject.tag = "AcilmisKartlar";

                }

                Kartlar[i].SetActive(true);

                donguSayaci++;
            }
        }
    }

    private int RastgeleKartNumarasiSec()
    {
        int rastgeleKartNumarasi = UnityEngine.Random.Range(0, 40);

        KartlariKontrolEt(rastgeleKartNumarasi);

        return rastgeleKartNumarasi;
    }

    IEnumerator BastanBasla(float saniye)
    {
        yield return new WaitForSeconds(saniye);
        SceneManager.LoadScene(0);
    }
    IEnumerator DogruIkon(float saniye)
    {
        sinifCagir.GetComponent<Kart>().dogruIkon.SetActive(true);
        yield return new WaitForSeconds(saniye);
        sinifCagir.GetComponent<Kart>().dogruIkon.SetActive(false);
    }
    IEnumerator YanlisIkon(float saniye)
    {
        sinifCagir.GetComponent<Kart>().yanlisIkon.SetActive(true);
        yield return new WaitForSeconds(saniye);
        sinifCagir.GetComponent<Kart>().yanlisIkon.SetActive(false);
    }
}

