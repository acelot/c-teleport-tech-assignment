namespace CTeleport.AirportsService.Api.DistanceApi.ValueObjects
{
    /// <summary>
    /// A value object that provides its type name
    /// </summary>
    public interface ITypedValueObject
    {
        /// <summary>
        /// Entity type
        /// </summary>
        string Type { get; }
    }
}