using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.TextCore.Text;
using UnityEngine;
using UnityEngine.UI;

public class WebsiteManager : QuestItem
{
    public GameObject newFE;

    public enum FireExtinguisherType
    {
        ABC = 0,
        water = 1,
        carbonDioxide = 2,
        wetChemical = 3
    }

    private static string ABC_DESC = "Multi-purpose extinguisher that works on most types of fire, including fire cause by flammable item, electronic item and organic materials.\n" +
        "DO NOT USE IT IN ENCLOSED KITCHEN FIRES!";

    private static string WATER_DESC = "Spraying water to the fire and put out the fire by itself. Works with fire cause by paper, wood, and other flammable solid materials\n" +
        "DO NOT USE IT TO PUT OUT FIRE INVOLVING ELECTRONIC EQUIPMENT, LIQUID / GAS AND KITCHEN FIRES!";

    private static string CARBON_DIOXIDE_DESC = "Commonly used for electrical related fires.\n" +
        "DO NOT USE IT TO PUT OUT ANY NON-ELECTRICAL RELATED FIRES!";

    private static string WET_CHEMICAL_DESC = "Commonly used in kitchen, but also can be used in cloth, paper and plastics fires.\n" +
        "DO NOT USE IT TO PUT OUT FIRES INVOLVING FLAMMABLE LIQUID / GAS / METAL AND ELECTRONIC EQUIPMENT ";

    private static string SUCCESS_TEXT = "Purchased successfully, please come again!";
    private static string WRONG_TEXT = "Not this one, read properly!";
    private static string BROKE_TEXT = "Stop buying, you're broke! :(";

    private WaitForSeconds wait = new WaitForSeconds(1f);

    public TextMeshProUGUI descText;
    public RawImage image;
    public GameObject fireExtinguisherPrefab;
    public static int selectedFireExtinguisher = -1;

    public Texture abcImage;
    public Texture waterImage;
    public Texture carbonDioxideImage;
    public Texture wetChemicalImage;
    public TextMeshProUGUI feedbackText;

    private bool done = false;

    public void ABCClicked()
    {
        descText.text = ABC_DESC;
        selectedFireExtinguisher = (int)FireExtinguisherType.ABC;
        image.texture = abcImage;
        image.color = Color.white;
    }


    public void WaterClicked()
    {
        descText.text = WATER_DESC;
        selectedFireExtinguisher = (int)FireExtinguisherType.water;
        image.texture = waterImage;
        image.color = Color.white;
    }

    public void CarbonDioxideClicked()
    {
        descText.text = CARBON_DIOXIDE_DESC;
        selectedFireExtinguisher = (int)FireExtinguisherType.carbonDioxide;
        image.texture = carbonDioxideImage;
        image.color = Color.white;
    }


    public void WetChemicalClicked()
    {
        descText.text = WET_CHEMICAL_DESC;
        selectedFireExtinguisher = (int)FireExtinguisherType.wetChemical;
        image.texture = wetChemicalImage;
        image.color = Color.white;
    }

    public void BuyFireExtinguisher()
    {

        //check is kitchen or not
        if (selectedFireExtinguisher == (int)FireExtinguisherType.wetChemical && !done)
        {
            //boughtFireExtinguisher = Instantiate(fireExtinguisherPrefab, new Vector3(4.3f, 0.388f, 1.55f), Quaternion.Euler(-90, 0, 0));
            newFE.SetActive(true);

            Complete();
            Feedback(SUCCESS_TEXT, Color.green);
            done = true;
        }
        else if (done)
        {
            Feedback(BROKE_TEXT, Color.yellow);
        }
        else
        {
            Feedback(WRONG_TEXT, Color.red);
        }
    }

    private void Feedback(string feedback, Color color)
    {
        feedbackText.gameObject.SetActive(true);
        feedbackText.color = color;
        feedbackText.text = feedback;

        StartCoroutine(DelayFeedbackDisappear());
    }

    IEnumerator DelayFeedbackDisappear()
    {
        yield return wait;

        feedbackText.gameObject.SetActive(false);
    }
}
