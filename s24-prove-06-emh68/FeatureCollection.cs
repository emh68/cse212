namespace prove_06
{
    public class FeatureCollection
    {
        // Todo Problem 5 - ADD YOUR CODE HERE
        // Create additional classes as necessary
        public List<Feature>? Features { get; set; }
    }

    public class Feature
    {
        // Properties object within each Feature
        public Properties? Properties { get; set; }
    }

    public class Properties
    {
        // Property for place
        public string? Place { get; set; }

        // Property for magnitude
        public double? Mag { get; set; }
    }
}
