using MarvelEntity.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PostGreWithMarvel.Interface;
using PostGreWithMarvel.Services;
using PostGreWithMarvel.Settings;

namespace PostGreWithMarvel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlobController : ControllerBase
    {
        private readonly IStorageProvider _storageProvider;
        private readonly UserDbContext _dbContext;
        private readonly string _bucketName;

        public BlobController(IStorageProvider storageProvider, UserDbContext dbContext, IOptions<MinIoOptions> minioOptions)
        {
            _storageProvider = storageProvider;
            _dbContext = dbContext;
            _bucketName = minioOptions.Value.BucketName;
        }

        [HttpGet]
        public async Task<ActionResult<string>> GetPresignedUrl(string fileName)
        {
            var urlFile = await _storageProvider.GetPresignedUrl(fileName);
            return Ok(urlFile);
        }

        [HttpGet("redirect")]
        public async Task<ActionResult<string>> GetPresignedUrlRedirect(string fileName)
        {
            var urlFile = await _storageProvider.GetPresignedUrl(fileName);
            return Redirect(urlFile);
        }

        [HttpGet("presigned-put-object")]
        public async Task<ActionResult<string>> GetPutPresignedUrl(string fileName)
        {
            var urlFile = await _storageProvider.GetPutPresignedUrl(fileName);
            return Ok(urlFile);
        }

        [HttpPost("blob-information")]
        public async Task<ActionResult<string>> PostBlobInformation(Guid id, string fileName, string mime)
        {
            var blob = new Blob
            {
                BlobId = id,
                FileName = fileName,
                CreatedAt = DateTimeOffset.UtcNow,
                FilePath = $"{_bucketName}/{id}",
                MIME = mime,
            };
            this._dbContext.Blobs.Add(blob);
            await this._dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("delete-object")]
        public async Task<ActionResult<string>> DeleteObject(string fileName, string fileExtension)
        {
            await this._storageProvider.DeleteFileAsync(fileName, fileExtension);
            return Ok();
        }
    }
}
