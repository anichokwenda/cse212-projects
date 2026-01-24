// This file is no longer needed separately, as the FeatureCollection, Feature, and Properties
// classes are included in SetsAndMaps.cs to accommodate JSON deserialization.

// If needed elsewhere, you can move the following classes here:
using System.Text.Json.Serialization;

public class FeatureCollection
{
    [JsonPropertyName("features")]
    public List<Features> Features { get; set; }
}

public class Features
{
    [JsonPropertyName("properties")]
    public Properties Properties { get; set; }
}

public class Properties
{
    [JsonPropertyName("place")]
    public string Place { get; set; }

    [JsonPropertyName("mag")]
    public double? Mag { get; set; }
}