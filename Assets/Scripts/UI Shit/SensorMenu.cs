using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SensorMenu : MonoBehaviour {

    public GameObject SelectedSensor;

    public GameObject List;

    // Use this for initialization
    public void SetAge(float Value)
    {
        SelectedSensor.GetComponent<SensorScript>().Age = Value;
        if (Value == 0)
        {
            List.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "Off";
        }
        else
        {
            List.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = Mathf.Round(Value).ToString();
        }
    }

    public void SetHunger(float Value)
    {
        SelectedSensor.GetComponent<SensorScript>().Hunger = Value;
        if (Value == 0)
        {
            print(List.name);
            List.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = "Off";
        }
        else
        {
            List.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = Mathf.Round(Value).ToString();
        }
    }

    public void SetSexDrive(float Value)
    {
        SelectedSensor.GetComponent<SensorScript>().SexDrive = Value;
        if (Value == 0)
        {
            List.transform.GetChild(2).GetChild(1).GetComponent<Text>().text = "Off";
        }
        else
        {
            List.transform.GetChild(2).GetChild(1).GetComponent<Text>().text = Mathf.Round(Value).ToString();
        }
    }

    public void SetMorality(float Value)
    {
        SelectedSensor.GetComponent<SensorScript>().Morality = Value;
        if (Value == 0)
        {
            List.transform.GetChild(3).GetChild(1).GetComponent<Text>().text = "Off";
        }
        else
        {
            List.transform.GetChild(3).GetChild(1).GetComponent<Text>().text = Mathf.Round(Value).ToString();
        }
    }

    public void SetPregnancy(float Value)
    {
        SelectedSensor.GetComponent<SensorScript>().Pregnancy = Value;
        if (Value == 0)
        {
            List.transform.GetChild(4).GetChild(1).GetComponent<Text>().text = "Off";
        }
        else
        {
            List.transform.GetChild(4).GetChild(1).GetComponent<Text>().text = Mathf.Round(Value).ToString();
        }
    }

    public void SetSex(float Value)
    {
        SelectedSensor.GetComponent<SensorScript>().Sex = Mathf.RoundToInt(Value);
        if (Value == -1)
        {
            List.transform.GetChild(5).GetChild(1).GetComponent<Text>().text = "Off";
        }
        else if (Value == 0)
        {
            List.transform.GetChild(5).GetChild(1).GetComponent<Text>().text = "Male";
        }
        else if (Value == 1)
        {
            List.transform.GetChild(5).GetChild(1).GetComponent<Text>().text = "Female";
        }
    }

    public void SetCannibal(float Value)
    {
        SelectedSensor.GetComponent<SensorScript>().Cannibal = Value;
        if (Value == 0)
        {
            List.transform.GetChild(6).GetChild(1).GetComponent<Text>().text = "Off";
        }
        else
        {
            List.transform.GetChild(6).GetChild(1).GetComponent<Text>().text = Mathf.Round(Value).ToString();
        }
    }

    public void SetFluffLength(float Value)
    {
        SelectedSensor.GetComponent<SensorScript>().FluffLength = Mathf.RoundToInt(Value);
        if (Value == -1)
        {
            List.transform.GetChild(7).GetChild(1).GetComponent<Text>().text = "Off";
        }
        else if (Value == 0)
        {
            List.transform.GetChild(7).GetChild(1).GetComponent<Text>().text = "Short";
        }
        else if (Value == 1)
        {
            List.transform.GetChild(7).GetChild(1).GetComponent<Text>().text = "Medium";
        }
        else if (Value == 2)
        {
            List.transform.GetChild(7).GetChild(1).GetComponent<Text>().text = "Long";
        }
    }

    public void SetSize(float Value)
    {
        SelectedSensor.GetComponent<SensorScript>().Size = Value;
        if (Value == 0.9f)
        {
            List.transform.GetChild(8).GetChild(1).GetComponent<Text>().text = "Off";
        }
        else
        {
            List.transform.GetChild(8).GetChild(1).GetComponent<Text>().text = Mathf.Round(Value).ToString();
        }
    }

    public void SetRace(float Value)
    {
        SelectedSensor.GetComponent<SensorScript>().Race = Mathf.RoundToInt(Value);
        if (Value == -1)
        {
            List.transform.GetChild(9).GetChild(1).GetComponent<Text>().text = "Off";
        } else if (Value == 0)
        {
            List.transform.GetChild(9).GetChild(1).GetComponent<Text>().text = "Earth";
        }
        else if (Value == 1)
        {
            List.transform.GetChild(9).GetChild(1).GetComponent<Text>().text = "Pegasus";
        }
        else if (Value == 2)
        {
            List.transform.GetChild(9).GetChild(1).GetComponent<Text>().text = "Unicorn";
        }
        else if (Value == 3)
        {
            List.transform.GetChild(9).GetChild(1).GetComponent<Text>().text = "Alicorn";
        }
    }

    public void SetUse(bool Value)
    {
        SelectedSensor.GetComponent<SensorScript>().CheckVariables = Value;
    }

}
