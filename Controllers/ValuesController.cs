using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace s3.demo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IAmazonS3 _s3client;
        public ValuesController(IAmazonS3 s3client)
        {
            _s3client = s3client;
        }


        [HttpPost("create")]
        public async Task<IActionResult> CreateBucketAsync(string bucketName)
        {
            var bucketExists = await _s3client.DoesS3BucketExistAsync(bucketName);
            if (bucketExists) return BadRequest($"Bucket {bucketName} already exists.");
            await _s3client.PutBucketAsync(bucketName);
            return Ok($"Bucket {bucketName} created.");

            
        }



    }
}
