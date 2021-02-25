using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using MarketplaceAPI.Data;
using MarketplaceAPI.Dtos;
using MarketplaceAPI.Helpers;
using MarketplaceAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketplaceAPI.Controllers
{
    [EnableCors]
    [Route("api/auctions/{auctionId}/photos")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private readonly IAuctionsRepository _auctionsRepository;
        private readonly IPhotosRepository _photosRepository;
        private readonly IOptions<CloudinarySettings> _cloudinaryConfig;
        private Cloudinary _cloudinary;

        public PhotosController(IOptions<CloudinarySettings> cloudinaryConfig, IAuctionsRepository auctionsRepository, IPhotosRepository photosRepository)
        {
            _cloudinaryConfig = cloudinaryConfig;
            _auctionsRepository = auctionsRepository;
            _photosRepository = photosRepository;

            Account account = new Account(
                _cloudinaryConfig.Value.CloudName,
                _cloudinaryConfig.Value.ApiKey,
                _cloudinaryConfig.Value.ApiSecret
            );

            _cloudinary = new Cloudinary(account);
        }

        [HttpPost]
        public async Task<IActionResult> AddPhotoToAuction(int auctionId, [FromForm] PhotoDto photoForAdd)
        {
            var auction = await _auctionsRepository.Get(auctionId);

            var file = photoForAdd.File;

            var uploadResult = new ImageUploadResult();

            if (file == null)
            {
                return StatusCode(422);
            }

            else if (file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(file.Name, stream),
                        Transformation = new Transformation()
                            .Width(500).Height(500)
                    };

                    uploadResult = _cloudinary.Upload(uploadParams);
                }

                photoForAdd.Url = uploadResult.Url.ToString();
                photoForAdd.PublicId = uploadResult.PublicId;
            }

            var photo = new Photo
            {
                AuctionId = auctionId,
                PublicId = photoForAdd.PublicId,
                Url = photoForAdd.Url,
            };

            if (auction.Photos == null)
            {
                auction.Photos = new List<Photo>();
                
            }
            auction.Photos.Add(photo);
            
            await _photosRepository.Add(photo);

            return Ok();
        }

        [HttpGet("1")]
        public async Task<string> GetFirstPhoto(int auctionId)
        {
            var photo = await _photosRepository.GetFirstPhoto(auctionId);

            return photo.Url;
        }

    }
}
