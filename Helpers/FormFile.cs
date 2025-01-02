namespace MusicLibrary.Helpers
{
    public class FormFile : IFormFile
    {
        private readonly byte[] _fileBytes;
        private readonly string _fileName;

        public FormFile(byte[] fileBytes, string fileName)
        {
            _fileBytes = fileBytes;
            _fileName = fileName;
        }

        public Stream OpenReadStream()
        {
            return new MemoryStream(_fileBytes);
        }

        public void CopyTo(Stream target)
        {
            using (var stream = new MemoryStream(_fileBytes))
            {
                stream.CopyTo(target);
            }
        }

        public async Task CopyToAsync(Stream target, CancellationToken cancellationToken = default)
        {
            await using (var stream = new MemoryStream(_fileBytes))
            {
                await stream.CopyToAsync(target, 81920, cancellationToken);
            }
        }

        public string ContentType { get; set; } = "application/octet-stream";
        public string ContentDisposition { get; set; }
        public IHeaderDictionary Headers { get; set; } = new HeaderDictionary();
        public long Length => _fileBytes.Length;
        public string Name { get; set; } = "file";
        public string FileName => _fileName;
    }

}
