using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TT.Abp.OssManagement;
using TT.Oss;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Settings;

namespace TT.SoMall.Controllers
{
    public class HomeController : AbpController
    {
        private readonly ISettingProvider _setting;

        public HomeController(ISettingProvider setting)
        {
            _setting = setting;
        }

        public ActionResult Index()
        {
            return Redirect("/swagger");
        }

        [HttpPost]
        public IActionResult ListFriends([FromBody] dynamic payload)
        {
            return Json(GroupChatHub.ConnectedParticipants((string) payload.currentUserId));
        }


        private async Task<UpYun> GetUploader()
        {
            var bucketName = await _setting.GetOrNullAsync(OssManagementSettings.BucketName);
            var domain = await _setting.GetOrNullAsync(OssManagementSettings.DomainHost);
            var pwd = await _setting.GetOrNullAsync(OssManagementSettings.AccessKey);
            var username = await _setting.GetOrNullAsync(OssManagementSettings.AccessId);
            return new UpYun(bucketName, username,
                pwd, domain);
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file, [FromForm(Name = "ng-chat-participant-id")]
            string userId)
        {
            // Storing file in temp path
            var filePath = Path.Combine(Path.GetTempPath(), file.FileName);

            if (file.Length > 0)
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }

            var baseUri = new Uri($"{Request.Scheme}://{Request.Host}{Request.PathBase}");

            var upyun = await GetUploader();
            var result = upyun.writeFile($"/somall/chat/{userId}/{file.FileName}", file.GetAllBytes(),
                true);

            if (result)
            {
                var path = $"{upyun.Domain}/somall/chat/{userId}/{file.FileName}";

                return Ok(new
                {
                    type = 2, // MessageType.File = 2
                    //fromId: ngChatSenderUserId, fromId will be set by the angular component after receiving the http response
                    toId = userId,
                    message = file.FileName,
                    mimeType = file.ContentType,
                    fileSizeInBytes = file.Length,
                    downloadUrl = path
                });
            }

            return Ok(new
            {
                type = 1, // MessageType.File = 2
                //fromId: ngChatSenderUserId, fromId will be set by the angular component after receiving the http response
                toId = userId,
                message = "发送图片,但失败了",
            });
        }
    }
}