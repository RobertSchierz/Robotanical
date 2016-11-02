using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]
public class Plant {

    private int specificId;
    private int plantiId;
	private string plantName;
    private string plantType;
    private int developmentTime;
    private float x;
    private float y;
    private float z;


    public Plant createPlant(int plantnumber, float _x, float _y, float _z)
    {
        this.plantiId = plantnumber;
        this.specificId = Random.Range(1, 10000);
        this.x = _x;
        this.y = _y;
        this.z = _z;

        foreach (Plant plant in Savesystem.savesystem.saveslot.plantsSetList)
        {
            if (this.specificId == plant.specificId)
            {
                do
                {
                    this.specificId = Random.Range(1, 10000);
                } while (this.specificId != plant.specificId);
            }
        }

        switch (plantiId)
        {
            case 0:
                this.plantName = "Kürbis";
                this.plantType = "Gemüse";
                this.developmentTime = 30;

                break;

            case 1:
                this.plantName = "Apfel";
                this.plantType = "Obst";
                this.developmentTime = 50;

                break;

            default:
                break;
        }

        return this;

    }
}



