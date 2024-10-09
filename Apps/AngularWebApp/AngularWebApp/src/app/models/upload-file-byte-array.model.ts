export class UploadFileByteArrayModel {
    /**
     Represents the form file to be uploaded.
     @param FileBytes The actual file object selected by the user as a number[].
     @param FileName The original name of the file as selected.
     @param CustomFileName The custom name for the file provided by the user, if any.
     @param FilePathTarget The target folder path where the file should be uploaded.
    */
    constructor(
        public FileBytes: number[],
        public FileName: string,
        public CustomFileName: string,
        public FilePathTarget: string
    ) {}
}
