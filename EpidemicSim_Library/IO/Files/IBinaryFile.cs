namespace PSC2013.ES.Library.IO.Files
{
    /// <summary>
    /// Types can implement this Interface to provide a binary representation of themselves.
    /// This is mainly used for serialization of these types.
    /// </summary>
    public interface IBinaryObject
    {
        /// <summary>
        /// Returns a binary representation of the IBinaryObject
        /// </summary>
        /// <returns>A byte[] containing all of the IBinaryObject's data</returns>
        byte[] GetBytes();
    }
}