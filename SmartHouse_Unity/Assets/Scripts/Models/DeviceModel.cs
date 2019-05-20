using System.Collections.Generic;

[System.Serializable]
public class DeviceModel
{
    public int Id;
    public string Type;
    public string Name;
    public string Localization;
    public bool Disabled;
    public string State;
    public List<string> AvailableActions;
}
