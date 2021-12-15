using API.Models;
using API.Models.Authorization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ExportVideoManager.Models.Resource
{
    public class VideoResources : BaseModel, ISoftDeletableModel, ILoggableUserActionModel
    {
        [Required]
        [DefaultValue("")]
        public string ResourcesId { get; set; }
        [Required]
        [DefaultValue("")]
        public string VideoExportId { get; set; }
        public virtual List<VideoExport> VideoExport { get; set; }
        [Required]
        [DefaultValue(0)]
        public CategoriesResource CategoriesResource { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }
        public string UpdatedByUserId { get; set; }
        public User UpdatedByUser { get; set; }
        public string DeletedByUserId { get; set; }
        public User DeletedByUser { get; set; }
    }

    public enum CategoriesResource
    {
        Image=1,
        Video=2,
        Audio=3,
        ThirdParty=4
    }

}
