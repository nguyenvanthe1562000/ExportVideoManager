using API.Models;
using API.Models.Authorization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace ExportVideoManager.Models.Resource
{
    //quản lý các thông tin được gửi từ editor  extension nào phòng trường hợp không đáng có.
    public class Editor : BaseModel, ISoftDeletableModel, ILoggableUserActionModel
    {
        [DefaultValue("0")] // 0 : không nhóm , 1 là nhóm 
        public bool IsGroup { get; set; }

        [DefaultValue("-1")] // id của nhóm 
        public string ParentId { get; set; }

        public string Code { get; set; } // vd adobe primeire ABP , audio ADU,...
        public string Name { get; set; }
        public string Version { get; set; }
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
