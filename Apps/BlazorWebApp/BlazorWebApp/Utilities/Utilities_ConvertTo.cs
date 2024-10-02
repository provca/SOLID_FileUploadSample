using Microsoft.AspNetCore.Components.Forms;

namespace BlazorWebApp.Utilities
{
    public class Utilities_ConvertTo
    {
        /// <summary>
        /// Converts the selected file into a byte array.
        /// </summary>
        /// <param name="file">The browser file to convert.</param>
        /// <returns>A byte array representing the file's content.</returns>
        public static async Task<byte[]> ConvertToByteArray(IBrowserFile file)
        {
            using (var stream = file.OpenReadStream())
            {
                // Creates a buffer to hold the file data.
                byte[] buffer = new byte[file.Size];

                // Reads the file data into the buffer.
                await stream.ReadAsync(buffer, 0, (int)file.Size);

                // Returns the buffer containing the file data as a byte array.
                return buffer;
            }
        }
    }
}
