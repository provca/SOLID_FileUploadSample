﻿using LibFilesManager.Enums;
using LibFilesManager.Interfaces;
using LibServices.Interfaces;

namespace LibServices.Adapters
{
    /// <summary>
    /// Adapter class for converting an <see cref="IFileService"/> instance into an <see cref="IFile"/>.
    /// Specifically designed for use in Windows Forms projects.
    /// </summary>
    public class WinFormsFileToIFileServiceAdapter : IFile
    {
        private readonly IFileService _fileService;

        /// <summary>
        /// Initializes a new instance of the <see cref="WinFormsFileToIFileServiceAdapter"/> class.
        /// </summary>
        /// <param name="fileService">An instance of <see cref="IFileService"/> to be adapted.</param>
        public WinFormsFileToIFileServiceAdapter(IFileService fileService)
        {
            _fileService = fileService;
        }

        /// <inheritdoc />
        public string FileName => Path.GetFileName(_fileService.FileName);

        /// <inheritdoc />
        public string Extension => Path.GetExtension(_fileService.FileName);

        /// <inheritdoc />
        public string ContentType => GetMimeType();

        /// <inheritdoc />
        public long Length => _fileService.Length;

        /// <inheritdoc />
        public Stream OpenReadStream() => _fileService.OpenReadStream();

        /// <inheritdoc />
        private string GetMimeType()
        {
            string extension = Extension.ToLowerInvariant().Replace(".", string.Empty);
            return extension switch
            {
                nameof(ImageFileExtensions.jpg) => "image/jpg",
                nameof(ImageFileExtensions.jpeg) => "image/jpeg",
                nameof(ImageFileExtensions.png) => "image/png",
                nameof(ImageFileExtensions.gif) => "image/gif",
                _ => "application/octet-stream",
            };
        }
    }
}
