using API.Constants;
using API.Models;
using API.Models.Authorization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace ExportVideoManager.Models.Resource
{
    public class VideoResources : BaseModel, ISoftDeletableModel, ILoggableUserActionModel
    {


        [Required]
        [DefaultValue("")]
        public string ResourcesId { get; set; }
        [Required]
        [Setting, DefaultValue(default(List<VideoExport>))]
        public virtual List<VideoExport> VideoExport { get; set; }                         //nếu không dùng cho youtube hoặc các kênh khác sẽ để empty 

        [Required]
        [Setting, DefaultValue(default(List<VideoExport>))]
        public virtual List<IntegratedResources> IntegratedResources { get; set; } //nếu không dùng cho IntegratedResources  sẽ để empty

        [Required]
        [DefaultValue(0)]
        public long StartTime { get; set; } //thời gian bắt đầu trong 1 video và kết thức
        [Required]
        [DefaultValue(0)]
        public long EndTime { get; set; } //thời gian bắt đầu trong 1 video và kết thức

        [Required]
        [DefaultValue(0)]
        public CategoriesResource FileType { get; set; }

        [Required]
        [DefaultValue(0)]
        public ResuourceType ResuourceType { get; set; }

        [Required]
        [DefaultValue(0)]
        public RenderType RenderType { get; set; }

        //------------------------------------
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }
        public string UpdatedByUserId { get; set; }
        public User UpdatedByUser { get; set; }
        public string DeletedByUserId { get; set; }
        public User DeletedByUser { get; set; }


    }
  
}




