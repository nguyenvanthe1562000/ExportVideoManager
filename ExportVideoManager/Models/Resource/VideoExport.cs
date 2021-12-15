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

        [Required]
        [StringLength(200)]
        [DefaultValue("")]
        public string Name { get; set; }

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
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }
        public string UpdatedByUserId { get; set; }
        public User UpdatedByUser { get; set; }
        public string DeletedByUserId { get; set; }
        public User DeletedByUser { get; set; }
    }

    public enum FileType
    {
      
        Audio = 1,
        Video = 2,
       
    }
}
