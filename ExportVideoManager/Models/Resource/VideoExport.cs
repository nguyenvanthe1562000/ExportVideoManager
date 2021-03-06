using API.Constants;
using API.Models;
using API.Models.Authorization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExportVideoManager.Models.Resource
{

    public class VideoExport : BaseModel, ISoftDeletableModel, ILoggableUserActionModel
    {
        [DefaultValue("")]
        public string ResourceFileId { get; private set; }
        [Required]
        [DefaultValue("")]
        public string Name { get; set; }

        [Required]
        [DefaultValue("")]
        public Editor EditorCode { get; set; }

        [DefaultValue(FileType.Video)]
        public FileType FileType { get; set; }
        [DefaultValue(0)]
        public long Size { get; set; }  // byte
        [DefaultValue(0)]        
        public long Length { get; set; } //
        [Required]
        [DefaultValue("")]
        public string UserId { get; set; }
        public User RegistrationUser { get; set; }
        public virtual List<VideoResources> VideoResource { get; set; }



        //---------------
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }
        public string UpdatedByUserId { get; set; }
        public User UpdatedByUser { get; set; }
        public string DeletedByUserId { get; set; }
        public User DeletedByUser { get; set; }

        public void SetResourceFileId(string resourceFileId)
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
                        case FileType.Video:
                            id = ResourceConst.ResourceFileId_VideoPrefix + guid;
                            break;
                        case FileType.Audio:
                            id = ResourceConst.ResourceFileId_AudioPrefix + guid;
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

    public enum FileType
    {
      
        Audio = 1,
        Video = 2,
     
       
    }
}
