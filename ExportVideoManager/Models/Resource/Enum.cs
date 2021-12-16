namespace ExportVideoManager.Models.Resource
{
 
    public enum CategoriesResource //loại tài nguyên được sử dụng
    {
        Image = 1,
        Video = 2,
        Audio = 3,
        ThirdParty = 4,
        IntegratedResources = 5
    }

    // loại tài nguyên được sử dụng ở đâu vd: 1 audio 10p được tạo từ 3 audio=> IntegratedResource
    public enum RenderType
    {
        Integrated = 0,
        VideoExport = 1
    }

    public enum ResuourceType //để biết loại tài nguyên  được công ty quản lý hay của người dùng.
    {
        FCP = 0, // đã được công ty quản lý file company
        FUS = 1,//chưa được công ty quản lý file user
    }
}
