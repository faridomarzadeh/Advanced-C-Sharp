namespace FactoryPattern.Sample
{
    public class SampleOne : ISampleOne
    {
        public string CurrentDateTime { get; set; } = DateTime.Now.ToString();

    }
}
