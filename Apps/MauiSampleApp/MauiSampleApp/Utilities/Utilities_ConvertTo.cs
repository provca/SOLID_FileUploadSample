namespace MauiSampleApp.Utilities
{
    /// <summary>
    /// Provides utility methods for data conversion.
    /// </summary>
    internal class Utilities_ConvertTo
    {
        /// <summary>
        /// Converts a selected file into a byte array asynchronously.
        /// </summary>
        /// <param name="file">The file to convert, represented by a <see cref="FileResult"/> object.</param>
        /// <returns>A byte array containing the file's data.</returns>
        public static async Task<byte[]> ConvertToByteArray(FileResult file)
        {
            // Opens a read-only stream for the file.
            using var stream = await file.OpenReadAsync();

            // Creates a memory stream to hold the file data.
            using var memoryStream = new MemoryStream();

            // Copies the file's data into the memory stream.
            await stream.CopyToAsync(memoryStream);

            // Returns the memory stream as a byte array.
            return memoryStream.ToArray();
        }
    }
}

