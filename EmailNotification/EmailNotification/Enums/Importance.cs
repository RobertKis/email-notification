using System.Text.Json.Serialization;

//[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Importance
{
    Low,
    Normal,
    High
}