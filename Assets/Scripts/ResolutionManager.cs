using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class ResolutionManager : MonoBehaviour
{
  public TMP_Dropdown resolutionDropdown;
  public TextMeshProUGUI saveButtonText;

  private Resolution[] resolutions;

  private void Start()
  {
    resolutions = Screen.resolutions;

    // Create a HashSet to store unique resolution options
    HashSet<string> uniqueOptions = new HashSet<string>();

    // Clear the dropdown options
    resolutionDropdown.ClearOptions();

    foreach (Resolution resolution in resolutions)
    {
      string option = resolution.width + "x" + resolution.height;

      if (!uniqueOptions.Contains(option) && resolution.width >= 800 && resolution.height >= 600)
      {
        uniqueOptions.Add(option);
        resolutionDropdown.options.Add(new TMP_Dropdown.OptionData(option));
      }
    }

    resolutionDropdown.value = GetCurrentResolutionIndex();
    resolutionDropdown.RefreshShownValue();
  }

  public void SaveResolution()
  {
    string selectedOption = resolutionDropdown.options[resolutionDropdown.value].text;

    string[] resolutionValues = selectedOption.Split('x');
    int width = int.Parse(resolutionValues[0]);
    int height = int.Parse(resolutionValues[1]);

    float aspectRatio = (float)width / height;
    Screen.SetResolution(width, height, true);

    saveButtonText.text = "Resolution Saved!";
  }

  private int GetCurrentResolutionIndex()
  {
    Resolution currentResolution = Screen.currentResolution;
    for (int i = 0; i < resolutions.Length; i++)
    {
      if (resolutions[i].width == currentResolution.width && resolutions[i].height == currentResolution.height)
      {
        return i;
      }
    }
    return 0;
  }
}
