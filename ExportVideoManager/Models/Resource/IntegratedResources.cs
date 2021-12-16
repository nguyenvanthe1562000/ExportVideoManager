using API.Constants;
using API.Models;
using API.Models.Authorization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace ExportVideoManager.Models.Resource
{
    // quản lý 1 tài nguyên được tập hợp từ nhiều tài nguyên
    // mục đích tài nguyên này dùng cho các video up lên youtube hoặc kênh khác
    public class IntegratedResources : BaseModel, ISoftDeletableModel, ILoggableUserActionModel
    {

        [DefaultValue("")]
        public string ResourceFileId { get; set; }

        [DefaultValue("")]
        public Editor EditorCode { get; set; } //được tạo từ editor extension nào.

        [Required]
        [DefaultValue("")]
        public string Name { get; set; }

        [DefaultValue(CategoriesResource.Audio)] // loại file  sau khi được tập hợp từ nhiều tài nguyên
        public CategoriesResource FileType { get; set; }

        [Required]
        [DefaultValue("")]
        public string UserId { get; set; }
        public User RegistrationUser { get; set; }

        public virtual List<VideoResources> VideoResource { get; set; }

        //-------------------------------
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }
        public string UpdatedByUserId { get; set; }
        public User UpdatedByUser { get; set; }
        public string DeletedByUserId { get; set; }
        public User DeletedByUser { get; set; }

        public  void SetResourceFileId(string resourceFileId)
        {
            try
            {
                resourceFileId = resourceFileId?.Trim();
                string id = "";

                // check resource file Id is valid
                if (!string.IsNullOrEmpty(resourceFileId)
                    && resourceFileId.StartsWith(ResourceConst.ResourceFileId_AudioPrefix)
                    && resourceFileId.Length == ResourceConst.ResourceFileIdLength)
                {
                    ResourceFileId = resourceFileId;
                }
                else
                {

                    // if not valid
                    // => generate new one
                    var guid = Guid.NewGuid().ToString("N").ToUpper();
                    switch (FileType)
                    {
                        case CategoriesResource.Image:
                            id = ResourceConst.ResourceFileId_ImagePrefix + guid;
                            break;
                        case CategoriesResource.Video:
                            id = ResourceConst.ResourceFileId_VideoPrefix + guid;
                            break;
                        case CategoriesResource.Audio:
                            id = ResourceConst.ResourceFileId_AudioPrefix + guid;
                            break;
                        case CategoriesResource.ThirdParty:
                            id = ResourceConst.ResourceFileId_AudioPrefix + guid;
                            break;
                        case CategoriesResource.IntegratedResources:
                            id = ResourceConst.ResourceFileId_ThirdPartyPrefix + guid;
                            break;
                        default:
                            id = ResourceConst.ResourceFileId_ThirdPartyPrefix + guid;
                            break;
                    }                   
                    ResourceFileId = id;

                }
            }
            catch (Exception ex)
            {
                //var logger = Startup.ServiceProvider.GetService(typeof(ILogger)) as ILogger;
                //logger.Log(LogType.Error, ex.Message, (new StackTrace(ex, true)).GetFrames().Last());
                //throw;
            }
        }
    }
}
