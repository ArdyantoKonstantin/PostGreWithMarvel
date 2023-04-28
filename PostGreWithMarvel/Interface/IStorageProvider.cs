namespace PostGreWithMarvel.Interface
{
    public interface IStorageProvider
    {
        /// <summary>
        /// Get presigned URL
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public Task<string> GetPresignedUrl(string fileName);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public Task<string> GetPutPresignedUrl(string fileName);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="fileExtension"></param>
        /// <returns></returns>
        public Task DeleteFileAsync(string fileName, string fileExtension);
    }
}
