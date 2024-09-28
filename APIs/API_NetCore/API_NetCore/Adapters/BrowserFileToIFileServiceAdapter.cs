using LibServices.DataManager.Interfaces;
using Microsoft.AspNetCore.Components.Forms;

namespace API_NetCore.Adapters
{
    public class BrowserFileToIFileServiceAdapter : IFileService
    {
        private readonly IBrowserFile _browserFile;

        /// <summary>
        /// Initializes a new instance of the <see cref="BrowserFileToIFileServiceAdapter"/> class.
        /// </summary>
        /// <param name="formFile">An instance of <see cref="IBrowserFile"/> to be adapted.</param>
        public BrowserFileToIFileServiceAdapter(IBrowserFile formFile)
        {
            _browserFile = formFile;
        }

        /// <inheritdoc />
        public string FileName => _browserFile.Name;

        /// <inheritdoc />
        public string Extension => Path.GetExtension(_browserFile.Name);

        /// <inheritdoc />
        public string ContentType => _browserFile.ContentType;

        /// <inheritdoc />
        public long Length => _browserFile.Size;

        /// <inheritdoc />
        public Stream OpenReadStream() => _browserFile.OpenReadStream();
    }
}
