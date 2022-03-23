using System;

namespace DocumentProcessing.Domain {
    public class Class1 { }
}

public partial class Welcome5 {
    [JsonProperty ("setup")]
    public Setup Setup { get; set; }
}

public partial class Setup {
    [JsonProperty ("locations")]
    public Locations Locations { get; set; }
}

public partial class Locations {
    [JsonProperty ("location")]
    public Location[] Location { get; set; }
}

public partial class Location {
    [JsonProperty ("countries")]
    public Countries Countries { get; set; }

    [JsonProperty ("environments")]
    public Environments Environments { get; set; }

    [JsonProperty ("_name")]
    public string Name { get; set; }
}

public partial class Countries {
    [JsonProperty ("country")]
    public CountryUnion Country { get; set; }
}

public partial class CountryElement {
    [JsonProperty ("_name")]
    public string Name { get; set; }
}

public partial class Environments {
    [JsonProperty ("environment")]
    public Environment[] Environment { get; set; }
}

public partial class Environment {
    [JsonProperty ("_name")]
    public string Name { get; set; }

    [JsonProperty ("_backend")]
    public Uri Backend { get; set; }
}

public partial struct CountryUnion {
    public CountryElement CountryElement;
    public CountryElement[] CountryElementArray;

    public static implicit operator CountryUnion (CountryElement CountryElement) => new CountryUnion { CountryElement = CountryElement };
    public static implicit operator CountryUnion (CountryElement[] CountryElementArray) => new CountryUnion { CountryElementArray = CountryElementArray };
}

public partial class Welcome5 {
    public static Welcome5 FromJson (string json) => JsonConvert.DeserializeObject<Welcome5> (json, CodeBeautify.Converter.Settings);
}

public static class Serialize {
    public static string ToJson (this Welcome5 self) => JsonConvert.SerializeObject (self, CodeBeautify.Converter.Settings);
}